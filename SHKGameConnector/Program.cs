using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Xml.Linq;
using ServerInterface;
using CommonTypes;
using CustomSinks;

namespace SHKGameConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Stronghold Kingdoms Game Connector ===");
            Console.WriteLine();
            
            // Читаем учетные данные из .env файла
            string email = GetEnvVariable("GAME_EMAIL");
            string password = GetEnvVariable("GAME_PASSWORD");
            
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Ошибка: не найдены GAME_EMAIL или GAME_PASSWORD в .env файле");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"Email: {email}");
            Console.WriteLine();
            
            try
            {
                // Шаг 1: Авторизация через XML-RPC
                Console.WriteLine("Шаг 1: Авторизация через XML-RPC...");
                var authResult = AuthenticateAsync(email, password).Result;
                
                if (!authResult.Success)
                {
                    Console.WriteLine($"Ошибка авторизации: {authResult.Message}");
                    Console.ReadKey();
                    return;
                }
                
                Console.WriteLine($"✅ Авторизация успешна!");
                Console.WriteLine($"UserGUID: {authResult.UserGuid}");
                Console.WriteLine($"SessionGUID: {authResult.SessionGuid}");
                Console.WriteLine();
                
                // Шаг 2: Подключение к игровому серверу
                Console.WriteLine("Шаг 2: Подключение к игровому серверу Europa 10...");
                
                IService gameServer = ConnectToGameServer();
                if (gameServer == null)
                {
                    Console.WriteLine("Ошибка подключения к игровому серверу");
                    Console.ReadKey();
                    return;
                }
                
                Console.WriteLine("✅ Подключено к игровому серверу");
                Console.WriteLine();
                
                // Шаг 3: Авторизация на игровом сервере
                Console.WriteLine("Шаг 3: Авторизация на игровом сервере...");
                
                int userId = 0;
                int sessionId = 0;
                
                try
                {
                    dynamic loginResult = gameServer.LoginUserGuid(
                        email,
                        authResult.UserGuid,
                        authResult.SessionGuid,
                        true, // needVillageData
                        1 // versionID
                    );
                    
                    if (loginResult == null)
                    {
                        Console.WriteLine("Ошибка: loginResult is null");
                        Console.ReadKey();
                        return;
                    }
                    
                    // Выводим все свойства для отладки
                    Console.WriteLine("\nСвойства loginResult:");
                    var loginType = loginResult.GetType();
                    foreach (var prop in loginType.GetProperties())
                    {
                        try
                        {
                            var value = prop.GetValue(loginResult);
                            Console.WriteLine($"  {prop.Name}: {value}");
                        }
                        catch { }
                    }
                    
                    // Проверяем Success
                    bool success = false;
                    try { success = loginResult.Success; } catch { }
                    
                    if (!success)
                    {
                        Console.WriteLine($"\n❌ Ошибка авторизации на игровом сервере");
                        Console.ReadKey();
                        return;
                    }
                    
                    Console.WriteLine($"\n✅ Авторизация на игровом сервере успешна!");
                    
                    // Пробуем разные варианты имен полей
                    try { userId = loginResult.UserID; } catch { }
                    try { if (userId == 0) userId = loginResult.userID; } catch { }
                    try { if (userId == 0) userId = loginResult.UserId; } catch { }
                    
                    try { sessionId = loginResult.SessionID; } catch { }
                    try { if (sessionId == 0) sessionId = loginResult.sessionID; } catch { }
                    try { if (sessionId == 0) sessionId = loginResult.SessionId; } catch { }
                    
                    Console.WriteLine($"UserID: {userId}");
                    Console.WriteLine($"SessionID: {sessionId}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n❌ ОШИБКА при вызове LoginUserGuid:");
                    Console.WriteLine($"Тип: {ex.GetType().Name}");
                    Console.WriteLine($"Сообщение: {ex.Message}");
                    
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"\nВнутренняя ошибка:");
                        Console.WriteLine($"Тип: {ex.InnerException.GetType().Name}");
                        Console.WriteLine($"Сообщение: {ex.InnerException.Message}");
                    }
                    
                    Console.WriteLine("\nНажмите любую клавишу для выхода...");
                    Console.ReadKey();
                    return;
                }
                
                // Шаг 4: Получение координат деревень
                Console.WriteLine("Шаг 4: Получение координат деревень...");
                
                dynamic villagesResult = gameServer.GetVillageNames(userId, sessionId, -1, 0);
                
                if (villagesResult == null)
                {
                    Console.WriteLine("Ошибка: villagesResult is null");
                    Console.ReadKey();
                    return;
                }
                
                // Выводим свойства для отладки
                Console.WriteLine("\nСвойства villagesResult:");
                var villagesType = villagesResult.GetType();
                foreach (var prop in villagesType.GetProperties())
                {
                    try
                    {
                        var value = prop.GetValue(villagesResult);
                        if (value != null && !value.GetType().IsArray)
                            Console.WriteLine($"  {prop.Name}: {value}");
                        else if (value != null)
                            Console.WriteLine($"  {prop.Name}: Array[{((Array)value).Length}]");
                    }
                    catch { }
                }
                
                // Получаем массив деревень
                dynamic villageData = null;
                try { villageData = villagesResult.villageData; } catch { }
                try { if (villageData == null) villageData = villagesResult.VillageData; } catch { }
                
                int villageCount = 0;
                if (villageData != null)
                {
                    try { villageCount = villageData.Length; } catch { }
                }
                
                Console.WriteLine($"\n✅ Получено деревень: {villageCount}");
                Console.WriteLine();
                
                // Шаг 5: Сохранение координат
                Console.WriteLine("Шаг 5: Сохранение координат...");
                
                var villages = new List<VillageData>();
                
                if (villageData != null && villageCount > 0)
                {
                    for (int i = 0; i < Math.Min(villageCount, 20); i++)
                    {
                        try
                        {
                            dynamic village = villageData[i];
                            
                            int villageId = 0;
                            string villageName = "";
                            int x = 0;
                            int y = 0;
                            
                            try { villageId = village.villageID; } catch { }
                            try { if (villageId == 0) villageId = village.VillageID; } catch { }
                            
                            try { villageName = village.villageName; } catch { }
                            try { if (string.IsNullOrEmpty(villageName)) villageName = village.VillageName; } catch { }
                            
                            try { x = village.xCoord; } catch { }
                            try { if (x == 0) x = village.XCoord; } catch { }
                            try { if (x == 0) x = village.X; } catch { }
                            
                            try { y = village.yCoord; } catch { }
                            try { if (y == 0) y = village.YCoord; } catch { }
                            try { if (y == 0) y = village.Y; } catch { }
                            
                            villages.Add(new VillageData
                            {
                                VillageId = villageId,
                                Name = villageName,
                                X = x,
                                Y = y
                            });
                            
                            Console.WriteLine($"  [{villageId}] {villageName} ({x}, {y})");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"  Ошибка обработки деревни {i}: {ex.Message}");
                        }
                    }
                    
                    if (villageCount > 20)
                    {
                        Console.WriteLine($"  ... показаны первые 20 из {villageCount}");
                        
                        // Добавляем остальные без вывода
                        for (int i = 20; i < villageCount; i++)
                        {
                            try
                            {
                                dynamic village = villageData[i];
                                
                                int villageId = 0;
                                string villageName = "";
                                int x = 0;
                                int y = 0;
                                
                                try { villageId = village.villageID; } catch { }
                                try { if (villageId == 0) villageId = village.VillageID; } catch { }
                                try { villageName = village.villageName; } catch { }
                                try { if (string.IsNullOrEmpty(villageName)) villageName = village.VillageName; } catch { }
                                try { x = village.xCoord; } catch { }
                                try { if (x == 0) x = village.XCoord; } catch { }
                                try { y = village.yCoord; } catch { }
                                try { if (y == 0) y = village.YCoord; } catch { }
                                
                                villages.Add(new VillageData
                                {
                                    VillageId = villageId,
                                    Name = villageName,
                                    X = x,
                                    Y = y
                                });
                            }
                            catch { }
                        }
                    }
                }
                
                // Сохраняем в JSON
                string json = SerializeToJson(villages);
                File.WriteAllText("villages.json", json);
                
                Console.WriteLine();
                Console.WriteLine($"✅ Координаты сохранены в villages.json");
                Console.WriteLine();
                
                // Шаг 6: Отправка координат в прокси-сервер
                Console.WriteLine("Шаг 6: Отправка координат в прокси-сервер...");
                
                int successCount = 0;
                using (var client = new HttpClient())
                {
                    foreach (var village in villages)
                    {
                        try
                        {
                            var content = new StringContent(
                                $"{{\"id\":{village.VillageId},\"x\":{village.X},\"y\":{village.Y},\"name\":\"{village.Name}\"}}",
                                Encoding.UTF8,
                                "application/json"
                            );
                            
                            var response = client.PostAsync("http://localhost:5000/api/village", content).Result;
                            
                            if (response.IsSuccessStatusCode)
                            {
                                successCount++;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"  Ошибка отправки деревни {village.VillageId}: {ex.Message}");
                        }
                    }
                }
                
                Console.WriteLine($"✅ Отправлено в прокси-сервер: {successCount}/{villages.Count}");
                Console.WriteLine();
                Console.WriteLine("=== Готово! ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
            
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        
        static string GetEnvVariable(string name)
        {
            try
            {
                // Ищем .env в текущей директории
                string envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
                
                if (File.Exists(envPath))
                {
                    foreach (var line in File.ReadAllLines(envPath))
                    {
                        var trimmedLine = line.Trim();
                        
                        // Пропускаем пустые строки и комментарии
                        if (string.IsNullOrWhiteSpace(trimmedLine) || trimmedLine.StartsWith("#"))
                            continue;
                        
                        // Ищем строку с нужной переменной
                        if (trimmedLine.StartsWith(name + " =") || trimmedLine.StartsWith(name + "="))
                        {
                            var parts = trimmedLine.Split(new[] { '=' }, 2);
                            if (parts.Length == 2)
                            {
                                return parts[1].Trim();
                            }
                        }
                    }
                }
                
                // Если не нашли в файле, пробуем переменные окружения
                return Environment.GetEnvironmentVariable(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения .env: {ex.Message}");
                return null;
            }
        }
        
        static async System.Threading.Tasks.Task<AuthResult> AuthenticateAsync(string email, string password)
        {
            using (var client = new HttpClient())
            {
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
                
                var content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");
                var response = await client.PostAsync("http://login.strongholdkingdoms.com/services/auth.php", content);
                
                if (!response.IsSuccessStatusCode)
                {
                    return new AuthResult { Success = false, Message = $"HTTP {response.StatusCode}" };
                }
                
                var responseText = await response.Content.ReadAsStringAsync();
                
                // Парсим XML ответ
                var doc = XDocument.Parse(responseText);
                var members = doc.Descendants("member");
                
                string userGuid = null;
                string sessionGuid = null;
                string message = null;
                int successCode = 0;
                
                foreach (var member in members)
                {
                    var name = member.Element("name")?.Value;
                    var value = member.Element("value")?.Element("string")?.Value 
                        ?? member.Element("value")?.Element("int")?.Value;
                    
                    switch (name)
                    {
                        case "userguid":
                            userGuid = value;
                            break;
                        case "sessionid":
                            sessionGuid = value;
                            break;
                        case "message":
                            message = value;
                            break;
                        case "successcode":
                            int.TryParse(value, out successCode);
                            break;
                    }
                }
                
                if (successCode == 1 && !string.IsNullOrEmpty(userGuid) && !string.IsNullOrEmpty(sessionGuid))
                {
                    return new AuthResult
                    {
                        Success = true,
                        UserGuid = userGuid,
                        SessionGuid = sessionGuid,
                        Message = message
                    };
                }
                
                return new AuthResult { Success = false, Message = message ?? "Unknown error" };
            }
        }
        
        static IService ConnectToGameServer()
        {
            try
            {
                // Используем наш исправленный CompressedSink
                var properties = new System.Collections.Specialized.ListDictionary();
                
                var binaryClientFormatterSinkProvider = new System.Runtime.Remoting.Channels.BinaryClientFormatterSinkProvider();
                
                // Используем исправленный sink вместо оригинального
                var fixedCompressedSinkProvider = new FixedCompressedSinkProvider();
                binaryClientFormatterSinkProvider.Next = fixedCompressedSinkProvider;
                
                var channel = new HttpChannel(properties, binaryClientFormatterSinkProvider, null);
                ChannelServices.RegisterChannel(channel, false);
                
                Console.WriteLine("✅ HTTP канал зарегистрирован с исправленным CompressedSink");
                
                // Подключаемся к игровому серверу Europa 10
                string gameServerUrl = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem";
                var gameServer = (IService)Activator.GetObject(typeof(IService), gameServerUrl);
                
                // Устанавливаем credentials
                var channelSinkProperties = ChannelServices.GetChannelSinkProperties(gameServer);
                if (channelSinkProperties != null)
                {
                    channelSinkProperties["credentials"] = System.Net.CredentialCache.DefaultCredentials;
                }
                
                return gameServer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        
        static string SerializeToJson(List<VillageData> villages)
        {
            var sb = new StringBuilder();
            sb.AppendLine("[");
            
            for (int i = 0; i < villages.Count; i++)
            {
                var v = villages[i];
                sb.Append($"  {{\"villageId\":{v.VillageId},\"name\":\"{v.Name}\",\"x\":{v.X},\"y\":{v.Y}}}");
                
                if (i < villages.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }
            
            sb.AppendLine("]");
            return sb.ToString();
        }
        
        class AuthResult
        {
            public bool Success { get; set; }
            public string UserGuid { get; set; }
            public string SessionGuid { get; set; }
            public string Message { get; set; }
        }
        
        class VillageData
        {
            public int VillageId { get; set; }
            public string Name { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
