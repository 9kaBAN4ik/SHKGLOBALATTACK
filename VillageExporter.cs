using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Net;
using System.Xml;
using DotNetEnv;
using Newtonsoft.Json;

namespace VillageExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("  STRONGHOLD KINGDOMS - VILLAGE EXPORTER");
            Console.WriteLine("==============================================\n");

            // Загружаем .env
            Env.Load();
            string email = Environment.GetEnvironmentVariable("GAME_EMAIL");
            string password = Environment.GetEnvironmentVariable("GAME_PASSWORD");
            string serverUrl = Environment.GetEnvironmentVariable("shk_link");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(serverUrl))
            {
                Console.WriteLine("❌ Ошибка: Не заданы переменные в .env файле!");
                Console.WriteLine("Проверьте наличие: GAME_EMAIL, GAME_PASSWORD, shk_link");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Сервер: {serverUrl}\n");

            try
            {
                // Шаг 1: Авторизация через XML-RPC
                Console.WriteLine("Шаг 1: Авторизация...");
                var authResult = Authenticate(email, password);
                
                if (authResult == null)
                {
                    Console.WriteLine("❌ Ошибка авторизации!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"✅ Авторизация успешна!");
                Console.WriteLine($"UserGUID: {authResult.UserGuid}");
                Console.WriteLine($"SessionGUID: {authResult.SessionGuid}\n");

                // Шаг 2: Подключение к игровому серверу через .NET Remoting
                Console.WriteLine("Шаг 2: Подключение к игровому серверу...");
                
                var gameServer = ConnectToGameServer(serverUrl);
                if (gameServer == null)
                {
                    Console.WriteLine("❌ Не удалось подключиться к игровому серверу!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("✅ Подключение установлено!\n");

                // Шаг 3: Получение данных деревень
                Console.WriteLine("Шаг 3: Получение данных деревень...");
                
                var loginResult = gameServer.LoginUserGuid(
                    email,
                    authResult.UserGuid,
                    authResult.SessionGuid,
                    true,  // needVillageData
                    1      // versionID
                );

                if (loginResult == null)
                {
                    Console.WriteLine("❌ LoginUserGuid вернул null!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"✅ Получен ответ от сервера!");
                Console.WriteLine($"Тип ответа: {loginResult.GetType().Name}\n");

                // Шаг 4: Извлечение координат деревень
                Console.WriteLine("Шаг 4: Извлечение координат...");
                var villages = ExtractVillages(loginResult);

                if (villages.Count == 0)
                {
                    Console.WriteLine("⚠️ Не найдено ни одной деревни!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine($"✅ Найдено деревень: {villages.Count}\n");

                // Шаг 5: Сохранение в JSON
                Console.WriteLine("Шаг 5: Сохранение в файл...");
                string json = JsonConvert.SerializeObject(villages, Formatting.Indented);
                
                // Сохраняем в два места
                File.WriteAllText("villages.json", json);
                File.WriteAllText("../villages.json", json);  // В корень проекта
                
                Console.WriteLine("✅ Данные сохранены в villages.json\n");

                // Показываем первые 10 деревень
                Console.WriteLine("Первые 10 деревень:");
                Console.WriteLine("+---------+-------+-------+----------------------+");
                Console.WriteLine("| VillID  |   X   |   Y   | Name                 |");
                Console.WriteLine("+---------+-------+-------+----------------------+");
                
                for (int i = 0; i < Math.Min(10, villages.Count); i++)
                {
                    var v = villages[i];
                    string name = v.Name.Length > 20 ? v.Name.Substring(0, 17) + "..." : v.Name;
                    Console.WriteLine($"| {v.Id,-7} | {v.X,5} | {v.Y,5} | {name,-20} |");
                }
                Console.WriteLine("+---------+-------+-------+----------------------+");

                Console.WriteLine($"\n🎉 УСПЕХ! Экспортировано {villages.Count} деревень!");
                Console.WriteLine("\nТеперь загрузите файл villages.json на сервер Discord бота");
                Console.WriteLine("и используйте команду: !loadvillages\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static AuthResult Authenticate(string email, string password)
        {
            try
            {
                string xmlRequest = $@"<?xml version=""1.0""?>
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

                var request = WebRequest.Create("http://login.strongholdkingdoms.com/services/auth.php");
                request.Method = "POST";
                request.ContentType = "text/xml";

                byte[] data = Encoding.UTF8.GetBytes(xmlRequest);
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                using (var response = request.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = reader.ReadToEnd();
                    
                    // Парсим XML ответ
                    var doc = new XmlDocument();
                    doc.LoadXml(responseText);

                    string userGuid = null;
                    string sessionGuid = null;

                    var members = doc.SelectNodes("//member");
                    foreach (XmlNode member in members)
                    {
                        string name = member.SelectSingleNode("name")?.InnerText;
                        string value = member.SelectSingleNode("value/string")?.InnerText;

                        if (name == "userguid") userGuid = value;
                        if (name == "sessionid") sessionGuid = value;
                    }

                    if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(sessionGuid))
                    {
                        return new AuthResult
                        {
                            UserGuid = userGuid,
                            SessionGuid = sessionGuid
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка авторизации: {ex.Message}");
            }

            return null;
        }

        static dynamic ConnectToGameServer(string serverUrl)
        {
            try
            {
                // Регистрируем HTTP канал с CustomSinks
                var clientProvider = new CustomSinks.CustomClientSinkProvider();
                var props = new System.Collections.Hashtable();
                props["name"] = "http";
                props["priority"] = "1";

                var channel = new HttpClientChannel(props, clientProvider);
                ChannelServices.RegisterChannel(channel, false);

                // Подключаемся к серверу
                string remoteUrl = $"{serverUrl}/KingdomsRPC/Kingdoms.rem";
                var gameServer = Activator.GetObject(
                    Type.GetType("ServerInterface.IService, ServerInterface"),
                    remoteUrl
                );

                return gameServer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
                return null;
            }
        }

        static List<Village> ExtractVillages(object loginResult)
        {
            var villages = new List<Village>();

            try
            {
                // Используем рефлексию для извлечения данных
                var type = loginResult.GetType();
                
                // Ищем свойство с деревнями (обычно это VillageData, Villages, или подобное)
                var properties = type.GetProperties();
                
                foreach (var prop in properties)
                {
                    Console.WriteLine($"  Свойство: {prop.Name} ({prop.PropertyType.Name})");
                    
                    // Пробуем найти коллекцию деревень
                    if (prop.Name.ToLower().Contains("village") || 
                        prop.PropertyType.IsArray ||
                        prop.PropertyType.Name.Contains("List"))
                    {
                        var value = prop.GetValue(loginResult);
                        
                        if (value is System.Collections.IEnumerable enumerable)
                        {
                            foreach (var item in enumerable)
                            {
                                var village = ExtractVillageData(item);
                                if (village != null)
                                {
                                    villages.Add(village);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка извлечения деревень: {ex.Message}");
            }

            return villages;
        }

        static Village ExtractVillageData(object villageObj)
        {
            try
            {
                var type = villageObj.GetType();
                var props = type.GetProperties();

                int id = 0;
                int x = 0;
                int y = 0;
                string name = "";

                foreach (var prop in props)
                {
                    var value = prop.GetValue(villageObj);
                    
                    if (prop.Name.ToLower().Contains("id") && value is int)
                    {
                        id = (int)value;
                    }
                    else if (prop.Name.ToLower() == "x" && value is int)
                    {
                        x = (int)value;
                    }
                    else if (prop.Name.ToLower() == "y" && value is int)
                    {
                        y = (int)value;
                    }
                    else if (prop.Name.ToLower().Contains("name") && value is string)
                    {
                        name = (string)value;
                    }
                }

                if (id > 0 && (x > 0 || y > 0))
                {
                    return new Village
                    {
                        Id = id,
                        X = x,
                        Y = y,
                        Name = string.IsNullOrEmpty(name) ? $"Village {id}" : name
                    };
                }
            }
            catch
            {
                // Игнорируем ошибки для отдельных объектов
            }

            return null;
        }
    }

    class AuthResult
    {
        public string UserGuid { get; set; }
        public string SessionGuid { get; set; }
    }

    class Village
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
