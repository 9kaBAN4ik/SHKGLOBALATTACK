"""
Клиент для подключения к Stronghold Kingdoms через .NET Remoting
"""
import struct
import socket
from datetime import datetime
from dotenv import load_dotenv
import os

load_dotenv()

class SHKClient:
    def __init__(self):
        server_link = os.getenv('shk_link')
        # Парсим URL
        self.host = server_link.replace('http://', '').replace(':80', '')
        self.port = 80
        self.rpc_path = "/KingdomsRPC/Kingdoms.rem"
        
        self.username = None
        self.password = None
        self.user_id = None
        self.session_id = None
        
        print(f"Инициализация клиента для {self.host}:{self.port}")
        
    def _create_http_request(self, method_name, *args):
        """Создать HTTP запрос для .NET Remoting"""
        # .NET Remoting использует специальный формат
        # Нужно создать HTTP POST запрос с бинарными данными
        
        headers = {
            'Content-Type': 'application/octet-stream',
            'SOAPAction': f'"{method_name}"',
            '__RequestUri': self.rpc_path,
            '__RequestVerb': 'POST'
        }
        
        # TODO: Сериализация параметров в .NET Binary Format
        # Это очень сложный формат, нужна специальная библиотека
        
        return headers, b''
    
    def login(self, username, password):
        """Авторизация в игре"""
        self.username = username
        self.password = password
        
        print(f"Попытка авторизации: {username}")
        print(f"Сервер: http://{self.host}:{self.port}{self.rpc_path}")
        
        # Для .NET Remoting нужно:
        # 1. Создать HTTP POST запрос
        # 2. Сериализовать параметры в .NET Binary Format
        # 3. Отправить на сервер
        # 4. Десериализовать ответ
        
        # Это очень сложно реализовать на Python
        # Проще использовать C# прокси
        
        print("\n⚠️ ВНИМАНИЕ: Прямое подключение к .NET Remoting из Python очень сложно!")
        print("Рекомендуется использовать один из вариантов:")
        print("1. C# прокси-сервер (создам отдельный проект)")
        print("2. Перехват трафика через mitmproxy")
        print("3. Использование существующего клиента игры")
        
        return False
    
    def get_army_data(self, highest_seen=0):
        """Получить данные об армиях"""
        if not self.session_id:
            print("Ошибка: не авторизован")
            return None
        
        # TODO: Вызов RemoteServices.GetArmyData
        return None
    
    def get_incoming_attacks(self, village_id):
        """Получить входящие атаки на деревню"""
        armies = self.get_army_data()
        if not armies:
            return []
        
        # Фильтруем армии, которые идут на указанную деревню
        incoming = []
        for army in armies:
            if army.get('targetVillageID') == village_id:
                incoming.append({
                    'army_id': army.get('armyID'),
                    'arrival_time': army.get('serverEndTime'),
                    'from_village': army.get('homeVillageID'),
                    'troops': {
                        'peasants': army.get('numPeasants', 0),
                        'archers': army.get('numArchers', 0),
                        'pikemen': army.get('numPikemen', 0),
                        'swordsmen': army.get('numSwordsmen', 0),
                        'catapults': army.get('numCatapults', 0),
                    }
                })
        
        return incoming

if __name__ == "__main__":
    client = SHKClient()
    print(f"\nСервер: http://{client.host}:{client.port}{client.rpc_path}")
    print("\nДля подключения нужно создать C# прокси-сервер")
    print("Запустите: dotnet run --project SHKProxy")
