using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Xml.Linq;
using ServerInterface;
using CustomSinks;

namespace SimpleGameClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Simple Game Client (использует оригинальные DLL) ===\n");
            
            // Читаем credentials
            string email = "kara.bridges1991@comejoinuspro.org";
            string password = "0307koolKL123";
            
            try
            {
                // Шаг 1: XML-RPC авторизация
                Console.WriteLine("Шаг 1: Авторизация...");
                var authResult = Authenticate(email, password);
                
                if (!authResult.Success)
                {
                    Console.WriteLine($"Ошибка: {authResult.Message}");
                    Console.ReadKey();
                    return;
                }
                
                Console.WriteLine($"✅ UserGUID: {authResult.UserGuid}");
                Console.WriteLine($"✅ SessionGUID: {authResult.SessionGuid}\n");
                
                // Шаг 2: Подключение к игровому серверу с ОРИГИНАЛЬНЫМ CustomSinks
                Console.WriteLine("Шаг 2: Подключение к игровому серверу...");
                
                // Настраиваем канал ТОЧНО как в игре
                ServicePointManager.MaxServicePointIdleTime = 1;
                ListDictionary properties = new ListDictionary();
                
                BinaryClientFormatterSinkProvider binaryProvider = new BinaryClientFormatterSinkProvider();
                
                // Используем ОРИГИНАЛЬНЫЙ CustomSinks
                ListDictionary sinkProperties = new ListDictionary();
                ListDictionary providerData = new ListDictionary();
                sinkProperties.Add("customSinkType", "CompressedSink.CompressedClientSink, CustomSinks");
                
                CustomClientSinkProvider customProvider = new CustomClientSinkProvider(sinkProperties, providerData);
                binaryProvider.Next = customProvider;
                
                HttpChannel channel = new HttpChannel(properties, binaryProvider, null);
                ChannelServices.RegisterChannel(channel, false);
                
                Console.WriteLine("✅ Канал зарегистрирован\n");
                
                // Подключаемся
                string url = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem";
                IService service = (IService)Activator.GetObject(typeof(IService), url);
                
                // Устанавливаем credentials
                var channelSinkProperties = ChannelServices.GetChannelSinkProperties(service);
                if (channelSinkProperties != null)
                {
                    channelSinkProperties["credentials"] = CredentialCache.DefaultCredentials;
                }
                
                Console.WriteLine("✅ Подключено к серверу\n");
                
                // Шаг 3: Вызываем LoginUserGuid
                Console.WriteLine("Шаг 3: Авторизация на игровом сервере...");
                
                var loginResult = service.LoginUserGuid(
                    email,
                    authResult.UserGuid,
                    authResult.SessionGuid,
                    true,
                    1
                );
                
                Console.WriteLine($"✅ Результат получен!");
                Console.WriteLine($"Success: {loginResult.Success}");
                
                if (loginResult.Success)
                {
                    // Выводим все свойства
                    var type = loginResult.GetType();
                    foreach (var prop in type.GetProperties())
                    {
                        try
                        {
                            var value = prop.GetValue(loginResult);
                            Console.WriteLine($"  {prop.Name}: {value}");
                        }
                        catch { }
                    }
                }
                
                Console.WriteLine("\n✅ УСПЕХ! Подключение работает!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Ошибка: {ex.Message}");
                Console.WriteLine($"Тип: {ex.GetType().Name}");
                
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"\nВнутренняя ошибка: {ex.InnerException.Message}");
                }
                
                Console.WriteLine($"\nStack trace:\n{ex.StackTrace}");
            }
            
            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
        
        static AuthResult Authenticate(string email, string password)
        {
            using (var client = new HttpClient())
            {
                var xml = $@"<?xml version=""1.0""?>
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
                
                var content = new StringContent(xml, Encoding.UTF8, "text/xml");
                var response = client.PostAsync("http://login.strongholdkingdoms.com/services/auth.php", content).Result;
                
                if (!response.IsSuccessStatusCode)
                {
                    return new AuthResult { Success = false, Message = $"HTTP {response.StatusCode}" };
                }
                
                var responseText = response.Content.ReadAsStringAsync().Result;
                var doc = XDocument.Parse(responseText);
                
                string userGuid = null;
                string sessionGuid = null;
                
                foreach (var member in doc.Descendants("member"))
                {
                    var name = member.Element("name")?.Value;
                    var value = member.Element("value")?.Element("string")?.Value;
                    
                    if (name == "userguid") userGuid = value;
                    if (name == "sessionid") sessionGuid = value;
                }
                
                if (!string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(sessionGuid))
                {
                    return new AuthResult
                    {
                        Success = true,
                        UserGuid = userGuid,
                        SessionGuid = sessionGuid
                    };
                }
                
                return new AuthResult { Success = false, Message = "No GUID received" };
            }
        }
        
        class AuthResult
        {
            public bool Success { get; set; }
            public string UserGuid { get; set; }
            public string SessionGuid { get; set; }
            public string Message { get; set; }
        }
    }
}
