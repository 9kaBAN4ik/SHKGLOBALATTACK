"""
Тест сырого HTTP запроса к игровому серверу
Чтобы увидеть, что именно сервер отвечает
"""
import requests
from dotenv import load_dotenv
import os
import xml.etree.ElementTree as ET

load_dotenv()

email = os.getenv('GAME_EMAIL')
password = os.getenv('GAME_PASSWORD')

# Шаг 1: Авторизация через XML-RPC
print("Шаг 1: Авторизация...")

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

root = ET.fromstring(response.text)
userguid = None
sessionguid = None

for member in root.findall('.//member'):
    name = member.find('name')
    value = member.find('.//value')
    if name is not None and value is not None:
        if name.text == 'userguid':
            userguid = list(value)[0].text if len(value) > 0 else value.text
        elif name.text == 'sessionid':
            sessionguid = list(value)[0].text if len(value) > 0 else value.text

print(f"✅ UserGUID: {userguid}")
print(f"✅ SessionGUID: {sessionguid}")

# Шаг 2: Попытка подключения к игровому серверу
print("\nШаг 2: Отправка сырого запроса к игровому серверу...")

game_server_url = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem"

# Попробуем просто GET запрос
print("\n--- GET запрос ---")
try:
    response = requests.get(game_server_url, timeout=10)
    print(f"Status: {response.status_code}")
    print(f"Headers: {dict(response.headers)}")
    print(f"Content (first 500 chars):\n{response.text[:500]}")
except Exception as e:
    print(f"Ошибка: {e}")

# Попробуем POST с пустым телом
print("\n--- POST запрос (пустой) ---")
try:
    response = requests.post(game_server_url, data=b'', timeout=10)
    print(f"Status: {response.status_code}")
    print(f"Headers: {dict(response.headers)}")
    print(f"Content (first 500 chars):\n{response.text[:500]}")
except Exception as e:
    print(f"Ошибка: {e}")

# Попробуем POST с .NET Remoting заголовками
print("\n--- POST запрос (.NET Remoting headers) ---")
try:
    headers = {
        'Content-Type': 'application/octet-stream',
        'SOAPAction': '\"http://schemas.microsoft.com/clr/nsassem/ServerInterface.IService/LoginUserGuid\"',
    }
    response = requests.post(game_server_url, data=b'', headers=headers, timeout=10)
    print(f"Status: {response.status_code}")
    print(f"Headers: {dict(response.headers)}")
    print(f"Content (first 1000 chars):\n{response.text[:1000]}")
except Exception as e:
    print(f"Ошибка: {e}")
