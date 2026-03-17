using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ServerInterface;

namespace SHKProxy
{
    public class GameClient
    {
        private static GameClient _instance;
        private string _userGuid;
        private string _sessionGuid;
        private int _userId;
        private int _sessionId;
        private IGameServer _gameServer;
        
        public static GameClient Instance => _instance ??= new GameClient();
        
        public bool IsConnected { get; private set; }
        
        private GameClient()
        {
        }
        
        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                Console.WriteLine($"Авторизация: {email}");
                
                // Шаг 1: Авторизация через XML-RPC
                var authResult = await AuthenticateAsync(email, password);
                if (!authResult.Success)
                {
                    Console.WriteLine($"Ошибка авторизации: {authResult.Message}");
                    return false;
                }
                
                _userGuid = authResult.UserGuid;
                _sessionGuid = authResult.SessionGuid;
                
                Console.WriteLine($"UserGUID: {_userGuid}");
                Console.WriteLine($"SessionGUID: {_sessionGuid}");
                
                // Шаг 2: Подключение к игровому серверу через .NET Remoting
                Console.WriteLine("Подключение к игровому серверу...");
                
                if (!ConnectToGameServer())
                {
                    Console.WriteLine("Ошибка подключения к игровому серверу");
                    return false;
                }
                
                // Шаг 3: Авторизация на игровом сервере
                Console.WriteLine("Авторизация на игровом сервере...");
                
                var loginResult = LoginToGameServer(email);
                if (!loginResult)
                {
                    Console.WriteLine("Ошибка авторизации на игровом сервере");
                    return false;
                }
                
                IsConnected = true;
                Console.WriteLine("✅ Успешно подключено к игровому серверу!");
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при подключении: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        
        private async Task<AuthResult> AuthenticateAsync(string email, string password)
        {
            using var client = new HttpClient();
            
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
        
        private bool ConnectToGameServer()
        {
            try
            {
                // Регистрируем HTTP канал для .NET Remoting
                var channel = new HttpChannel();
                ChannelServices.RegisterChannel(channel, false);
                
                // Подключаемся к игровому серверу Europa 10
                string gameServerUrl = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem";
                _gameServer = (IGameServer)Activator.GetObject(typeof(IGameServer), gameServerUrl);
                
                return _gameServer != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения к игровому серверу: {ex.Message}");
                return false;
            }
        }
        
        private bool LoginToGameServer(string username)
        {
            try
            {
                // Вызываем LoginUserGuid на игровом сервере
                var result = _gameServer.LoginUserGuid(
                    username,
                    _userGuid,
                    _sessionGuid,
                    true, // needVillageData
                    "1.0.0" // version
                );
                
                if (result != null && result.Success)
                {
                    _userId = result.userID;
                    _sessionId = result.sessionID;
                    
                    Console.WriteLine($"UserID: {_userId}");
                    Console.WriteLine($"SessionID: {_sessionId}");
                    
                    return true;
                }
                
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка авторизации на игровом сервере: {ex.Message}");
                return false;
            }
        }
        
        public Dictionary<int, VillageCoordinates> GetAllVillageCoordinates()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Не подключено к игровому серверу");
            }
            
            try
            {
                Console.WriteLine("Получение координат деревень...");
                
                // Вызываем GetVillageNames для получения всех деревень
                var result = _gameServer.GetVillageNames(_userId, _sessionId, -1, 0);
                
                if (result == null || !result.Success)
                {
                    Console.WriteLine("Ошибка получения деревень");
                    return new Dictionary<int, VillageCoordinates>();
                }
                
                var coordinates = new Dictionary<int, VillageCoordinates>();
                
                if (result.villageData != null)
                {
                    foreach (var village in result.villageData)
                    {
                        coordinates[village.villageID] = new VillageCoordinates
                        {
                            VillageId = village.villageID,
                            X = village.xCoord,
                            Y = village.yCoord,
                            Name = village.villageName
                        };
                    }
                }
                
                Console.WriteLine($"Получено {coordinates.Count} деревень");
                
                return coordinates;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка получения координат: {ex.Message}");
                return new Dictionary<int, VillageCoordinates>();
            }
        }
        
        private class AuthResult
        {
            public bool Success { get; set; }
            public string UserGuid { get; set; }
            public string SessionGuid { get; set; }
            public string Message { get; set; }
        }
    }
}
