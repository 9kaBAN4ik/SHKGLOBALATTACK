using System;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Xml.Linq;
using ServerInterface;
using CustomSinks;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GameServerClient
{
    public class VillageData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class GameClient
    {
        private string email;
        private string password;
        private string userGuid;
        private string sessionGuid;
        private IService gameServer;

        public GameClient(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public async Task<bool> AuthenticateAsync()
        {
            Console.WriteLine("🔐 Авторизация через XML-RPC...");
            
            var xmlRequest = $@"<?xml version=""1.0""?>
<methodCall>
    <methodName>login</methodName>
    <params>
        <param>
            <value>
                <struct>
                    <member>
                        <name>username</name>
                        <value><string>{email}</string></value>
                    </member>
                    <member>
                        <name>emailaddress</name>
                        <value><string>{email}</string></value>
                    </member>
                    <member>
                        <name>password</name>
                        <value><string>{password}</string></value>
                    </member>
                </struct>
            </value>
        </param>
    </params>
</methodCall>";

            using (var client = new HttpClient())
            {
                var content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");
                var response = await client.PostAsync("http://login.strongholdkingdoms.com/services/auth.php", content);
                
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"❌ HTTP ошибка: {response.StatusCode}");
                    return false;
                }
                
                var responseText = await response.Content.ReadAsStringAsync();
                var doc = XDocument.Parse(responseText);
                
                foreach (var member in doc.Descendants("member"))
                {
                    var name = member.Element("name")?.Value;
                    var value = member.Element("value")?.Element("string")?.Value;
                    
                    if (name == "userguid") userGuid = value;
                    if (name == "sessionid") sessionGuid = value;
                }
                
                if (string.IsNullOrEmpty(userGuid) || string.IsNullOrEmpty(sessionGuid))
                {
                    Console.WriteLine("❌ Не получены GUID");
                    return false;
                }
                
                Console.WriteLine($"✅ UserGUID: {userGuid}");
                Console.WriteLine($"✅ SessionGUID: {sessionGuid}");
                return true;
            }
        }

        public bool ConnectToGameServer()
        {
            Console.WriteLine("🌐 Подключение к игровому серверу...");
            
            try
            {
                // Настраиваем .NET Remoting с исправленным CustomSinks
                ServicePointManager.MaxServicePointIdleTime = 1;
                ListDictionary properties = new ListDictionary();
                
                BinaryClientFormatterSinkProvider binaryProvider = new BinaryClientFormatterSinkProvider();
                ListDictionary sinkProperties = new ListDictionary();
                ListDictionary providerData = new ListDictionary();
                sinkProperties.Add("customSinkType", "CompressedSink.CompressedClientSink, CustomSinks");
                
                CustomClientSinkProvider customProvider = new CustomClientSinkProvider(sinkProperties, providerData);
                binaryProvider.Next = customProvider;
                
                HttpChannel channel = new HttpChannel(properties, binaryProvider, null);
                ChannelServices.RegisterChannel(channel, false);
                
                string url = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem";
                gameServer = (IService)Activator.GetObject(typeof(IService), url);
                
                var channelSinkProperties = ChannelServices.GetChannelSinkProperties(gameServer);
                if (channelSinkProperties != null)
                {
                    channelSinkProperties["credentials"] = CredentialCache.DefaultCredentials;
                }
                
                Console.WriteLine("✅ Подключено к игровому серверу");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка подключения: {ex.Message}");
                return false;
            }
        }

        public async Task<List<VillageData>> GetVillagesAsync()
        {
            Console.WriteLine("🏘️ Получение координат деревень...");
            
            try
            {
                // Авторизация на игровом сервере
                Console.WriteLine("Авторизация на игровом сервере...");
                
                var loginResult = gameServer.LoginUserGuid(
                    email,
                    userGuid, 
                    sessionGuid,
                    true,  // needVillageData
                    1      // versionID
                );
                
                if (!loginResult.Success)
                {
                    Console.WriteLine("❌ Ошибка авторизации на игровом сервере");
                    return new List<VillageData>();
                }
                
                Console.WriteLine("✅ Авторизация на игровом сервере успешна");
                
                // Получаем UserID и SessionID из результата
                int userId = 0;
                int sessionId = 0;
                
                var loginType = loginResult.GetType();
                foreach (var prop in loginType.GetProperties())
                {
                    try
                    {
                        var value = prop.GetValue(loginResult);
                        if (prop.Name.ToLower().Contains("userid"))
                            userId = Convert.ToInt32(value);
                        if (prop.Name.ToLower().Contains("sessionid"))
                            sessionId = Convert.ToInt32(value);
                    }
                    catch { }
                }
                
                Console.WriteLine($"UserID: {userId}, SessionID: {sessionId}");
                
                // Получаем список деревень
                Console.WriteLine("Получение списка деревень...");
                
                var villagesResult = gameServer.GetVillageNames(userId, sessionId, -1, 0);
                
                var villages = new List<VillageData>();
                
                // Парсим результат
                var villagesType = villagesResult.GetType();
                foreach (var prop in villagesType.GetProperties())
                {
                    try
                    {
                        var value = prop.GetValue(villagesResult);
                        if (value != null && value.GetType().IsArray)
                        {
                            var array = (Array)value;
                            Console.WriteLine($"Найден массив {prop.Name} с {array.Length} элементами");
                            
                            for (int i = 0; i < Math.Min(array.Length, 1000); i++) // Ограничиваем 1000 деревнями
                            {
                                try
                                {
                                    dynamic village = array.GetValue(i);
                                    
                                    var villageData = new VillageData();
                                    
                                    // Пробуем разные варианты имен полей
                                    var villageType = village.GetType();
                                    foreach (var villageProp in villageType.GetProperties())
                                    {
                                        try
                                        {
                                            var propValue = villageProp.GetValue(village);
                                            var propName = villageProp.Name.ToLower();
                                            
                                            if (propName.Contains("id") && !propName.Contains("session"))
                                                villageData.Id = Convert.ToInt32(propValue);
                                            else if (propName.Contains("name"))
                                                villageData.Name = propValue?.ToString() ?? "";
                                            else if (propName.Contains("x") || propName == "xcoord")
                                                villageData.X = Convert.ToInt32(propValue);
                                            else if (propName.Contains("y") || propName == "ycoord")
                                                villageData.Y = Convert.ToInt32(propValue);
                                        }
                                        catch { }
                                    }
                                    
                                    // Проверяем что получили валидные данные
                                    if (villageData.Id > 0 && villageData.X >= 0 && villageData.Y >= 0)
                                    {
                                        if (string.IsNullOrEmpty(villageData.Name))
                                            villageData.Name = $"Village_{villageData.Id}";
                                        
                                        villages.Add(villageData);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Ошибка обработки деревни {i}: {ex.Message}");
                                }
                            }
                            break; // Берем первый найденный массив
                        }
                    }
                    catch { }
                }
                
                Console.WriteLine($"✅ Получено {villages.Count} деревень");
                return villages;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка получения деревень: {ex.Message}");
                return new List<VillageData>();
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Console.WriteLine("============================================");
            Console.WriteLine("🎮 SHKGLOBALATTACK - Village Coordinate Fetcher");
            Console.WriteLine("============================================");
            Console.WriteLine();
            
            // Загрузка .env файла
            try
            {
                DotNetEnv.Env.Load();
                Console.WriteLine("✅ .env файл загружен");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Предупреждение при загрузке .env: {ex.Message}");
            }
            
            // Загрузка переменных окружения
            var email = Environment.GetEnvironmentVariable("GAME_EMAIL");
            var password = Environment.GetEnvironmentVariable("GAME_PASSWORD");
            
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("❌ GAME_EMAIL или GAME_PASSWORD не найдены в переменных окружения");
                Console.WriteLine("Пожалуйста, убедитесь что файл .env содержит:");
                Console.WriteLine("  GAME_EMAIL=your_email@example.com");
                Console.WriteLine("  GAME_PASSWORD=your_password");
                Console.WriteLine();
                Console.WriteLine($"Текущие значения:");
                Console.WriteLine($"  GAME_EMAIL: {(string.IsNullOrEmpty(email) ? "<не найдено>" : "<найдено>")}");
                Console.WriteLine($"  GAME_PASSWORD: {(string.IsNullOrEmpty(password) ? "<не найдено>" : "<найдено>")}");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"✅ Email: {email}");
            Console.WriteLine($"✅ Password: {new string('*', password.Length)}");
            Console.WriteLine();
            
            var client = new GameClient(email, password);
            
            // Аутентификация
            if (!await client.AuthenticateAsync())
            {
                Console.WriteLine("❌ Ошибка аутентификации");
                Console.ReadKey();
                return;
            }
            
            // Подключение к игровому серверу
            if (!client.ConnectToGameServer())
            {
                Console.WriteLine("❌ Ошибка подключения к игровому серверу");
                Console.ReadKey();
                return;
            }
            
            // Получение деревень
            var villages = await client.GetVillagesAsync();
            
            if (villages.Count == 0)
            {
                Console.WriteLine("❌ Деревни не найдены");
                Console.ReadKey();
                return;
            }
            
            // Сохранение в JSON
            var json = JsonConvert.SerializeObject(villages, Formatting.Indented);
            System.IO.File.WriteAllText("villages_data.json", json);
            
            Console.WriteLine();
            Console.WriteLine("============================================");
            Console.WriteLine($"✅ Успешно! Получено {villages.Count} деревень");
            Console.WriteLine($"📁 Данные сохранены в: villages_data.json");
            Console.WriteLine("============================================");
            
            // Показываем первые 5 деревень для примера
            Console.WriteLine();
            Console.WriteLine("Примеры деревень:");
            for (int i = 0; i < Math.Min(5, villages.Count); i++)
            {
                var v = villages[i];
                Console.WriteLine($"  - ID: {v.Id}, Name: {v.Name}, Coords: ({v.X}, {v.Y})");
            }
            
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
