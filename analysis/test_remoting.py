"""
Простой тест для проверки подключения к игровому серверу
Используем Python.NET для вызова .NET Remoting
"""

# Этот скрипт требует установки pythonnet:
# pip install pythonnet

try:
    import clr
    import sys
    
    # Добавляем путь к DLL
    sys.path.append('StrongholdKingdoms/bin/Debug')
    
    # Загружаем DLL
    clr.AddReference('ServerInterface')
    clr.AddReference('CommonTypes')
    clr.AddReference('System.Runtime.Remoting')
    
    from ServerInterface import IService
    from System import Activator, Type
    from System.Runtime.Remoting.Channels import ChannelServices
    from System.Runtime.Remoting.Channels.Http import HttpChannel
    
    print("✅ DLL загружены успешно")
    
    # Регистрируем канал
    channel = HttpChannel()
    ChannelServices.RegisterChannel(channel, False)
    
    print("✅ HTTP канал зарегистрирован")
    
    # Подключаемся к серверу
    url = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem"
    service = Activator.GetObject(Type.GetType("ServerInterface.IService"), url)
    
    print(f"✅ Подключено к {url}")
    print(f"Тип сервиса: {type(service)}")
    
    # Попробуем вызвать метод
    print("\nПопытка авторизации...")
    
    # Сначала нужно получить GUID через XML-RPC
    import requests
    from dotenv import load_dotenv
    import os
    import xml.etree.ElementTree as ET
    
    load_dotenv()
    email = os.getenv('GAME_EMAIL')
    password = os.getenv('GAME_PASSWORD')
    
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
    
    print(f"UserGUID: {userguid}")
    print(f"SessionGUID: {sessionguid}")
    
    # Теперь пробуем LoginUserGuid
    result = service.LoginUserGuid(email, userguid, sessionguid, True, 1)
    
    print(f"\nРезультат LoginUserGuid:")
    print(f"Тип: {type(result)}")
    print(f"Success: {result.Success}")
    
    # Выводим все свойства
    print("\nСвойства результата:")
    for attr in dir(result):
        if not attr.startswith('_'):
            try:
                value = getattr(result, attr)
                if not callable(value):
                    print(f"  {attr}: {value}")
            except:
                pass
    
except ImportError as e:
    print(f"❌ Ошибка импорта: {e}")
    print("\nУстановите pythonnet:")
    print("  pip install pythonnet")
except Exception as e:
    print(f"❌ Ошибка: {e}")
    import traceback
    traceback.print_exc()
