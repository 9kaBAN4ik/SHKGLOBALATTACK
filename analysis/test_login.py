"""
Тест авторизации в Stronghold Kingdoms через XML-RPC
"""
import requests
from dotenv import load_dotenv
import os
import xml.etree.ElementTree as ET

load_dotenv()

email = os.getenv('GAME_EMAIL')
password = os.getenv('GAME_PASSWORD')

# Из URLs.cs:
# ProfileProtocol = "http"
# ProfileServerAddressLogin = "login.strongholdkingdoms.com"
# ProfileServerPort = "80"
# ProfilePath = "/services/auth.php"

profile_server = "http://login.strongholdkingdoms.com"
auth_path = "/services/auth.php"

print(f"Email: {email}")
print(f"Авторизация через: {profile_server}{auth_path}")

# XML-RPC запрос для авторизации
# Из кода видно: new XmlRpcAuthRequest("", this.txtEmail.Text, this.txtEmail.Text, this.txtPassword.Text, "", "", "", "")
# Это означает что передаются 8 параметров в конструктор XmlRpcAuthRequest
# Но метод login принимает 1 параметр - struct с полями

# Попробуем вызвать метод login с struct параметром
# Нужно добавить Username - в игре используется email как username
# Попробуем lowercase имена полей
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

print(f"\n{'='*50}")
print(f"Отправка запроса...")
print(f"{'='*50}")

try:
    response = requests.post(
        f"{profile_server}{auth_path}",
        data=xml_request,
        headers={'Content-Type': 'text/xml'},
        timeout=10
    )
    
    print(f"\nStatus: {response.status_code}")
    print(f"Response:\n{response.text}")
    
    # Парсим ответ
    if response.status_code == 200:
        root = ET.fromstring(response.text)
        
        # Проверяем на ошибку
        fault = root.find('.//fault')
        if fault:
            print("\n❌ Ошибка авторизации")
            # Выводим детали ошибки
            for member in root.findall('.//member'):
                name = member.find('name')
                value = member.find('.//value')
                if name is not None and value is not None:
                    val_text = value.text or (list(value)[0].text if len(value) > 0 else "N/A")
                    print(f"  {name.text}: {val_text}")
        else:
            # Ищем данные пользователя
            params = root.find('.//params')
            if params:
                print("\n✅ Авторизация успешна!")
                print("Данные пользователя:")
                for member in root.findall('.//member'):
                    name = member.find('name')
                    value = member.find('.//value')
                    if name is not None and value is not None:
                        # Получаем значение из разных типов
                        val_elem = list(value)[0] if len(value) > 0 else value
                        val_text = val_elem.text if val_elem.text else str(val_elem.tag)
                        print(f"  {name.text}: {val_text}")
    
except Exception as e:
    print(f"\n❌ Error: {e}")
    import traceback
    traceback.print_exc()
