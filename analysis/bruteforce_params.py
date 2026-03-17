"""
Автоматический перебор параметров LoginUserGuid
Пробует разные комбинации, чтобы найти рабочую
"""
import subprocess
import time
import os

def test_params(username, user_guid, session_guid, need_village_data, version_id):
    """Тестирует одну комбинацию параметров"""
    print(f"\n{'='*60}")
    print(f"Тест: userName='{username}', needVillageData={need_village_data}, versionID={version_id}")
    print(f"{'='*60}")
    
    # Создаем временный C# файл с этими параметрами
    test_code = f"""
using System;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ServerInterface;
using CustomSinks;

class TestParams
{{
    static void Main()
    {{
        try
        {{
            ServicePointManager.MaxServicePointIdleTime = 1;
            ListDictionary properties = new ListDictionary();
            
            BinaryClientFormatterSinkProvider binaryProvider = new BinaryClientFormatterSinkProvider();
            ListDictionary sinkProperties = new ListDictionary();
            ListDictionary providerData = new ListDictionary();
            sinkProperties.Add("customSinkType", "CompressedSink.CompressedClientSink, CustomSinks");
            
            CustomClientSinkProvider customProvider = new CustomClientSinkProvider(sinkProperties, providerData);
            binaryProvider.Next = customProvider;
            
            HttpChannel channel = new HttpChannel(properties, binaryProvider, null);
            ChannelServices.RegisterChannel(channel, false);
            
            string url = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem";
            IService service = (IService)Activator.GetObject(typeof(IService), url);
            
            var channelSinkProperties = ChannelServices.GetChannelSinkProperties(service);
            if (channelSinkProperties != null)
                channelSinkProperties["credentials"] = CredentialCache.DefaultCredentials;
            
            var result = service.LoginUserGuid(
                "{username}",
                "{user_guid}",
                "{session_guid}",
                {str(need_village_data).lower()},
                {version_id}
            );
            
            Console.WriteLine("SUCCESS");
            Console.WriteLine($"Success: {{result.Success}}");
        }}
        catch (Exception ex)
        {{
            Console.WriteLine("FAILED");
            Console.WriteLine($"Error: {{ex.Message}}");
        }}
    }}
}}
"""
    
    # Сохраняем во временный файл
    with open('TestParams.cs', 'w', encoding='utf-8') as f:
        f.write(test_code)
    
    # Просто запускаем SimpleGameClient с разными параметрами
    # Модифицируем SimpleGameClient напрямую
    return False  # Пока не реализовано, используем другой подход
        
        if 'SUCCESS' in output:
            print(f"✅ УСПЕХ!")
            print(output)
            return True
        else:
            print(f"❌ Ошибка:")
            print(output[:200])
            return False
    except Exception as e:
        print(f"❌ Ошибка выполнения: {e}")
        return False
    finally:
        # Удаляем временные файлы
        try:
            os.remove('TestParams.cs')
            os.remove('TestParams.exe')
        except:
            pass

def get_session_guid():
    """Получает свежий SessionGUID через XML-RPC"""
    import requests
    import xml.etree.ElementTree as ET
    from dotenv import load_dotenv
    
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
    session_guid = None
    
    for member in root.findall('.//member'):
        name = member.find('name')
        value = member.find('.//value/string')
        if name is not None and value is not None:
            if name.text == 'sessionid':
                session_guid = value.text
                break
    
    return session_guid

def main():
    print("="*60)
    print("АВТОМАТИЧЕСКИЙ ПЕРЕБОР ПАРАМЕТРОВ")
    print("="*60)
    print()
    
    # Получаем свежий SessionGUID
    print("Получение SessionGUID...")
    session_guid = get_session_guid()
    
    if not session_guid:
        print("❌ Не удалось получить SessionGUID")
        return
    
    print(f"✅ SessionGUID: {session_guid}")
    print()
    
    user_guid = "5dbaf4019e9046409f8feb3b55c10137"
    email = "kara.bridges1991@comejoinuspro.org"
    
    # Комбинации для тестирования
    test_cases = [
        # (username, needVillageData, versionID)
        (email, True, 1),
        (email, False, 1),
        (email, True, 0),
        (email, False, 0),
        (email, True, 2),
        ("", True, 1),
        ("", False, 1),
        (email.split('@')[0], True, 1),  # Только имя без домена
        (user_guid, True, 1),  # GUID как username
    ]
    
    print(f"Будет протестировано {len(test_cases)} комбинаций")
    print()
    
    for i, (username, need_village, version) in enumerate(test_cases, 1):
        print(f"\n[{i}/{len(test_cases)}] ", end='')
        
        success = test_params(username, user_guid, session_guid, need_village, version)
        
        if success:
            print("\n" + "="*60)
            print("🎉 НАЙДЕНА РАБОЧАЯ КОМБИНАЦИЯ!")
            print("="*60)
            print(f"userName: '{username}'")
            print(f"userGuid: {user_guid}")
            print(f"sessionGuid: {session_guid}")
            print(f"needVillageData: {need_village}")
            print(f"versionID: {version}")
            print()
            print("Обнови SimpleGameClient/Program.cs с этими параметрами!")
            return
        
        time.sleep(1)  # Небольшая пауза между попытками
    
    print("\n" + "="*60)
    print("❌ Ни одна комбинация не сработала")
    print("="*60)
    print()
    print("Рекомендации:")
    print("1. Проверь, что игра работает (можешь войти вручную)")
    print("2. Попробуй захватить трафик через Wireshark")
    print("3. Возможно, нужны дополнительные параметры или другой метод")

if __name__ == '__main__':
    main()
