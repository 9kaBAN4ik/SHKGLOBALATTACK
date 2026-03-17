"""
Получение списка миров и выбор Europa 10
"""
import requests
from dotenv import load_dotenv
import os
import xml.etree.ElementTree as ET

load_dotenv()

email = os.getenv('GAME_EMAIL')
password = os.getenv('GAME_PASSWORD')

profile_server = "http://login.strongholdkingdoms.com"
auth_path = "/services/auth.php"

print("Шаг 1: Авторизация...")

# Авторизация
xml_login = f"""<?xml version="1.0"?>
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

try:
    response = requests.post(
        f"{profile_server}{auth_path}",
        data=xml_login,
        headers={'Content-Type': 'text/xml'},
        timeout=10
    )
    
    if response.status_code != 200:
        print(f"❌ Ошибка авторизации: {response.status_code}")
        exit(1)
    
    root = ET.fromstring(response.text)
    
    # Извлекаем userguid и sessionid
    userguid = None
    sessionid = None
    
    for member in root.findall('.//member'):
        name = member.find('name')
        value = member.find('.//value')
        if name is not None and value is not None:
            if name.text == 'userguid':
                userguid = list(value)[0].text if len(value) > 0 else value.text
            elif name.text == 'sessionid':
                sessionid = list(value)[0].text if len(value) > 0 else value.text
    
    if not userguid or not sessionid:
        print("❌ Не удалось получить userguid или sessionid")
        exit(1)
    
    print(f"✅ Авторизация успешна!")
    print(f"UserGUID: {userguid}")
    print(f"SessionID: {sessionid}")
    
    # Шаг 2: Получение списка миров
    print("\nШаг 2: Получение списка миров...")
    
    xml_get_worlds = f"""<?xml version="1.0"?>
<methodCall>
    <methodName>GetWorlds</methodName>
    <params>
        <param>
            <value>
                <struct>
                    <member>
                        <name>userguid</name>
                        <value><string>{userguid}</string></value>
                    </member>
                </struct>
            </value>
        </param>
    </params>
</methodCall>"""
    
    response = requests.post(
        f"{profile_server}{auth_path}",
        data=xml_get_worlds,
        headers={'Content-Type': 'text/xml'},
        timeout=10
    )
    
    if response.status_code != 200:
        print(f"❌ Ошибка получения миров: {response.status_code}")
        exit(1)
    
    print(f"✅ Получен список миров")
    
    # Парсим список миров
    root = ET.fromstring(response.text)
    
    # Ищем Europa 10 (world ID 756)
    print("\nПоиск Europa 10 (World ID 756)...")
    
    # Сохраняем ответ для анализа
    with open('worlds_response.xml', 'w', encoding='utf-8') as f:
        f.write(response.text)
    
    print("Ответ сохранен в worlds_response.xml")
    
    # Выводим первые несколько миров для анализа структуры
    print("\nСтруктура ответа:")
    for i, member in enumerate(root.findall('.//member')[:20]):
        name = member.find('name')
        if name is not None:
            print(f"  {name.text}")
    
except Exception as e:
    print(f"\n❌ Error: {e}")
    import traceback
    traceback.print_exc()
