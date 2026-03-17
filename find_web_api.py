import requests
import json
from dotenv import load_dotenv
import os

# Загружаем .env
load_dotenv()

class SHKWebAPI:
    def __init__(self, email, password):
        self.email = email
        self.password = password
        self.session = requests.Session()
        self.user_guid = None
        self.session_guid = None
        self.user_id = None
        self.session_id = None
        
    def authenticate(self):
        """Аутентификация через XML-RPC"""
        print("🔐 Авторизация...")
        
        xml_request = f"""<?xml version="1.0"?>
<methodCall>
    <methodName>login</methodName>
    <params>
        <param>
            <value>
                <struct>
                    <member>
                        <name>username</name>
                        <value><string>{self.email}</string></value>
                    </member>
                    <member>
                        <name>emailaddress</name>
                        <value><string>{self.email}</string></value>
                    </member>
                    <member>
                        <name>password</name>
                        <value><string>{self.password}</string></value>
                    </member>
                </struct>
            </value>
        </param>
    </params>
</methodCall>"""
        
        response = self.session.post(
            'http://login.strongholdkingdoms.com/services/auth.php',
            data=xml_request,
            headers={'Content-Type': 'text/xml'}
        )
        
        if response.status_code != 200:
            print(f"❌ Ошибка HTTP: {response.status_code}")
            return False
        
        # Парсим XML ответ
        import xml.etree.ElementTree as ET
        root = ET.fromstring(response.text)
        
        for member in root.findall('.//member'):
            name = member.find('name').text
            value = member.find('.//string')
            if value is not None:
                if name == 'userguid':
                    self.user_guid = value.text
                elif name == 'sessionid':
                    self.session_guid = value.text
        
        if not self.user_guid or not self.session_guid:
            print("❌ Не получены GUID")
            return False
        
        print(f"✅ UserGUID: {self.user_guid}")
        print(f"✅ SessionGUID: {self.session_guid}")
        return True
    
    def get_villages_via_web(self):
        """Получить координаты через веб-интерфейс игры"""
        print("\n🌐 Попытка получить данные через веб-интерфейс...")
        
        # Пробуем использовать веб API (если есть)
        # Stronghold Kingdoms может иметь REST API endpoints
        
        # Вариант 1: Попробуем получить данные профиля
        try:
            profile_url = f"http://shk-w756.elb.fireflyops.com:80/api/profile?userguid={self.user_guid}&sessionid={self.session_guid}"
            response = self.session.get(profile_url)
            print(f"Profile API status: {response.status_code}")
            if response.status_code == 200:
                print(response.text[:500])
        except Exception as e:
            print(f"Profile API failed: {e}")
        
        # Вариант 2: Попробуем получить список деревень
        try:
            villages_url = f"http://shk-w756.elb.fireflyops.com:80/api/villages?userguid={self.user_guid}&sessionid={self.session_guid}"
            response = self.session.get(villages_url)
            print(f"Villages API status: {response.status_code}")
            if response.status_code == 200:
                print(response.text[:500])
        except Exception as e:
            print(f"Villages API failed: {e}")
        
        # Вариант 3: Попробуем игровой endpoint
        try:
            game_url = f"http://shk-w756.elb.fireflyops.com:80/game"
            response = self.session.get(game_url, params={
                'userguid': self.user_guid,
                'sessionid': self.session_guid
            })
            print(f"Game endpoint status: {response.status_code}")
            if response.status_code == 200:
                print(response.text[:500])
        except Exception as e:
            print(f"Game endpoint failed: {e}")
        
        return []
    
    def search_village_by_id(self, village_id):
        """Поиск деревни по ID через игровой API"""
        print(f"\n🔍 Поиск деревни ID: {village_id}...")
        
        # Пробуем разные endpoints
        endpoints = [
            f"http://shk-w756.elb.fireflyops.com:80/village/{village_id}",
            f"http://shk-w756.elb.fireflyops.com:80/api/village/{village_id}",
            f"http://shk-w756.elb.fireflyops.com:80/game/village/{village_id}",
        ]
        
        for endpoint in endpoints:
            try:
                response = self.session.get(endpoint, params={
                    'userguid': self.user_guid,
                    'sessionid': self.session_guid
                })
                print(f"  {endpoint} -> {response.status_code}")
                if response.status_code == 200:
                    print(f"  Response: {response.text[:200]}")
                    return response.json() if 'json' in response.headers.get('content-type', '') else None
            except Exception as e:
                pass
        
        return None

if __name__ == '__main__':
    email = os.getenv('GAME_EMAIL')
    password = os.getenv('GAME_PASSWORD')
    
    if not email or not password:
        print("❌ GAME_EMAIL или GAME_PASSWORD не найдены в .env")
        exit(1)
    
    print("============================================")
    print("🎮 SHK Web API Village Finder")
    print("============================================\n")
    
    api = SHKWebAPI(email, password)
    
    if not api.authenticate():
        print("❌ Ошибка аутентификации")
        exit(1)
    
    # Пробуем получить деревни
    api.get_villages_via_web()
    
    # Пробуем поиск конкретной деревни
    test_villages = [103844, 458]
    for vid in test_villages:
        result = api.search_village_by_id(vid)
        if result:
            print(f"✅ Найдена деревня {vid}: {result}")
    
    print("\n============================================")
    print("Проверьте вывод выше для доступных endpoints")
    print("============================================")
