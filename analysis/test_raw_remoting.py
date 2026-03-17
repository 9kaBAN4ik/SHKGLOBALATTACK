"""
Попытка подключения к игровому серверу через сырые HTTP запросы
Обходим .NET Remoting и работаем напрямую с протоколом
"""
import requests
import struct
import gzip
import io
from dotenv import load_dotenv
import os
import xml.etree.ElementTree as ET

load_dotenv()

email = os.getenv('GAME_EMAIL')
password = os.getenv('GAME_PASSWORD')

def authenticate():
    """Авторизация через XML-RPC"""
    xml_request = f"""<?xml version="1.0"?>
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
</methodCall>"""
    
    response = requests.post(
        "http://login.strongholdkingdoms.com/services/auth.php",
        data=xml_request,
        headers={'Content-Type': 'text/xml'}
    )
    
    if response.status_code != 200:
        return None, None
    
    root = ET.fromstring(response.text)
    user_guid = None
    session_guid = None
    
    for member in root.findall('.//member'):
        name = member.find('name')
        value = member.find('.//value/string')
        if name is not None and value is not None:
            if name.text == 'userguid':
                user_guid = value.text
            elif name.text == 'sessionid':
                session_guid = value.text
    
    return user_guid, session_guid

def create_remoting_request(method_name, *args):
    """
    Создает .NET Remoting запрос в бинарном формате
    Это упрощенная версия - нужно будет доработать
    """
    # .NET Remoting использует BinaryFormatter
    # Формат очень сложный, нужно либо использовать библиотеку,
    # либо реверс-инжинирить протокол
    
    # Заголовок .NET Remoting
    data = bytearray()
    
    # Preamble
    data.append(0x00)  # Preamble start
    data.append(0x01)  # Major version
    data.append(0x00)  # Minor version
    
    # TODO: Добавить сериализацию вызова метода
    # Это требует глубокого понимания BinaryFormatter
    
    return bytes(data)

def test_raw_request():
    """Тестовый запрос к игровому серверу"""
    print("Шаг 1: Авторизация...")
    user_guid, session_guid = authenticate()
    
    if not user_guid or not session_guid:
        print("❌ Ошибка авторизации")
        return
    
    print(f"✅ UserGUID: {user_guid}")
    print(f"✅ SessionGUID: {session_guid}\n")
    
    print("Шаг 2: Попытка подключения к игровому серверу...")
    
    # URL игрового сервера
    url = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem"
    
    # Пробуем простой GET запрос для начала
    print(f"GET {url}")
    response = requests.get(url)
    
    print(f"Status: {response.status_code}")
    print(f"Headers: {dict(response.headers)}")
    print(f"Content ({len(response.content)} bytes):")
    
    # Пробуем декодировать как текст
    try:
        print(response.text[:500])
    except:
        print(response.content[:500])
    
    print("\n" + "="*60 + "\n")
    
    # Пробуем POST запрос с пустым телом
    print(f"POST {url} (empty body)")
    response = requests.post(url, data=b'')
    
    print(f"Status: {response.status_code}")
    print(f"Headers: {dict(response.headers)}")
    print(f"Content ({len(response.content)} bytes):")
    
    try:
        print(response.text[:500])
    except:
        print(response.content[:500])
    
    print("\n" + "="*60 + "\n")
    
    # Пробуем с заголовками .NET Remoting
    headers = {
        'Content-Type': 'application/octet-stream',
        'SOAPAction': '\"http://schemas.microsoft.com/clr/nsassem/ServerInterface.IService/LoginUserGuid\"',
        '__RequestUri': '/KingdomsRPC/Kingdoms.rem',
        '__RequestVerb': 'POST'
    }
    
    print(f"POST {url} (с .NET Remoting заголовками)")
    response = requests.post(url, data=b'', headers=headers)
    
    print(f"Status: {response.status_code}")
    print(f"Headers: {dict(response.headers)}")
    print(f"Content ({len(response.content)} bytes):")
    
    try:
        print(response.text[:1000])
    except:
        print(response.content[:500])

if __name__ == '__main__':
    test_raw_request()
