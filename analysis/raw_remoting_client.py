"""
Клиент для отправки сырых .NET Remoting запросов
Использует захваченные байты из Wireshark
"""
import requests
import xml.etree.ElementTree as ET
from dotenv import load_dotenv
import os

def get_session_guid():
    """Получает свежий SessionGUID через XML-RPC"""
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

def extract_request_bytes():
    """Извлекает байты запроса из захваченного файла"""
    try:
        with open('context_135450.bin', 'rb') as f:
            data = f.read()
        
        # Ищем email как начало полезных данных
        email_pos = data.find(b'kara.bridges1991@comejoinuspro.org')
        if email_pos == -1:
            print("❌ Email не найден")
            return None
        
        # Начинаем с байтов перед email (включая .NET Remoting заголовки)
        start_pos = max(0, email_pos - 100)  # Берем больше контекста
        
        # Ищем конец после SessionGUID + параметры
        session_guid_pos = data.find(b'd1823dc87dbd', email_pos)
        if session_guid_pos == -1:
            print("❌ SessionGUID не найден")
            return None
        
        # Берем еще больше байт после SessionGUID для всех параметров
        end_pos = session_guid_pos + 50  # Увеличиваем до 50 байт
        
        request_bytes = data[start_pos:end_pos]
        
        print(f"✅ Извлечено {len(request_bytes)} байт запроса")
        print(f"Начало: {request_bytes[:20].hex()}")
        print(f"Конец: {request_bytes[-20:].hex()}")
        
        # Сохраняем для анализа
        with open('extracted_request.bin', 'wb') as f:
            f.write(request_bytes)
        print("✅ Запрос сохранен в extracted_request.bin")
        
        return request_bytes
        
    except FileNotFoundError:
        print("❌ Файл context_135450.bin не найден")
        return None

def replace_session_guid(request_bytes, new_session_guid):
    """Заменяет SessionGUID в байтах запроса"""
    if not request_bytes:
        return None
    
    # Старый SessionGUID из захвата
    old_session_guid = b'7733c7c0-8f1a-4299-8fdb-d1823dc87dbd'
    
    # Форматируем новый GUID с дефисами
    if len(new_session_guid) == 32:  # Без дефисов
        # Добавляем дефисы: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
        formatted_guid = f"{new_session_guid[:8]}-{new_session_guid[8:12]}-{new_session_guid[12:16]}-{new_session_guid[16:20]}-{new_session_guid[20:]}"
    else:
        formatted_guid = new_session_guid
    
    new_session_guid_bytes = formatted_guid.encode('ascii')
    
    if len(new_session_guid_bytes) != len(old_session_guid):
        print(f"❌ Длина GUID не совпадает: {len(new_session_guid_bytes)} != {len(old_session_guid)}")
        return None
    
    # Заменяем
    modified_bytes = request_bytes.replace(old_session_guid, new_session_guid_bytes)
    
    if modified_bytes == request_bytes:
        print("❌ SessionGUID не найден для замены")
        return None
    
    print(f"✅ SessionGUID заменен: {old_session_guid.decode()} -> {formatted_guid}")
    return modified_bytes

def send_raw_request(request_bytes):
    """Отправляет сырой .NET Remoting запрос"""
    if not request_bytes:
        return None
    
    url = "http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem"
    
    headers = {
        'User-Agent': 'Mozilla/4.0+(compatible; MSIE 6.0; Windows 6.2.9200.0; MS .NET Remoting; MS .NET CLR 2.0.50727.9179 )',
        'Content-Type': 'application/octet-stream',
        'Host': 'shk-w756.elb.fireflyops.com',
        'Content-Length': str(len(request_bytes)),
        'Connection': 'Keep-Alive'
    }
    
    print(f"\n📤 Отправка запроса:")
    print(f"URL: {url}")
    print(f"Размер: {len(request_bytes)} байт")
    print(f"Заголовки: {headers}")
    
    try:
        response = requests.post(url, data=request_bytes, headers=headers, timeout=10)
        
        print(f"\n📥 Ответ получен:")
        print(f"Status: {response.status_code}")
        print(f"Headers: {dict(response.headers)}")
        print(f"Content-Length: {len(response.content)}")
        
        # Сохраняем ответ
        with open('response.bin', 'wb') as f:
            f.write(response.content)
        
        print(f"✅ Ответ сохранен в response.bin")
        
        # Пробуем проанализировать ответ
        if response.content:
            analyze_response(response.content)
        
        return response
        
    except Exception as e:
        print(f"❌ Ошибка отправки: {e}")
        return None

def analyze_response(response_data):
    """Анализирует ответ сервера"""
    print(f"\n🔍 Анализ ответа ({len(response_data)} байт):")
    
    # Проверяем на сжатие
    if len(response_data) >= 2 and response_data[0] == 0x1F and response_data[1] == 0x8B:
        print("✅ Ответ сжат GZIP")
        
        try:
            import gzip
            decompressed = gzip.decompress(response_data)
            print(f"Размер после распаковки: {len(decompressed)} байт")
            
            # Сохраняем распакованный ответ
            with open('response_decompressed.bin', 'wb') as f:
                f.write(decompressed)
            
            print("✅ Распакованный ответ сохранен в response_decompressed.bin")
            
            # Анализируем распакованные данные
            analyze_decompressed_data(decompressed)
            
        except Exception as e:
            print(f"❌ Ошибка распаковки: {e}")
    
    else:
        print("ℹ️ Ответ не сжат")
        
        # Проверяем на XML (ошибка)
        if response_data.startswith(b'<?xml'):
            print("❌ Сервер вернул XML ошибку")
            try:
                text = response_data.decode('utf-8')
                print(f"XML: {text[:200]}...")
            except:
                pass
        else:
            # Hex dump первых байт
            print("Первые 100 байт:")
            for i in range(0, min(100, len(response_data)), 16):
                chunk = response_data[i:i+16]
                hex_part = ' '.join(f'{b:02X}' for b in chunk)
                ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
                print(f"  {i:04X}: {hex_part:<48} {ascii_part}")

def analyze_decompressed_data(data):
    """Анализирует распакованные данные ответа"""
    print(f"\n🔍 Анализ распакованных данных:")
    
    # Ищем строки
    strings = []
    current_str = ""
    
    for byte in data:
        if 32 <= byte <= 126:  # Printable ASCII
            current_str += chr(byte)
        else:
            if len(current_str) >= 4:
                strings.append(current_str)
            current_str = ""
    
    if len(current_str) >= 4:
        strings.append(current_str)
    
    if strings:
        print(f"Найдено строк: {len(strings)}")
        for s in strings[:20]:  # Первые 20
            print(f"  '{s}'")
    
    # Ищем числа (координаты)
    print(f"\nПоиск координат (int32):")
    for i in range(0, len(data) - 3, 4):
        try:
            value = int.from_bytes(data[i:i+4], byteorder='little', signed=True)
            if 0 <= value <= 1000:  # Разумные координаты
                print(f"  Позиция {i}: {value}")
        except:
            pass

def main():
    print("="*60)
    print("СЫРОЙ .NET REMOTING КЛИЕНТ")
    print("="*60)
    print()
    
    # Шаг 1: Получить свежий SessionGUID
    print("Шаг 1: Получение SessionGUID...")
    session_guid = get_session_guid()
    
    if not session_guid:
        print("❌ Не удалось получить SessionGUID")
        return
    
    print(f"✅ SessionGUID: {session_guid}")
    
    # Шаг 2: Извлечь байты запроса
    print("\nШаг 2: Извлечение байтов запроса...")
    request_bytes = extract_request_bytes()
    
    if not request_bytes:
        print("❌ Не удалось извлечь байты запроса")
        return
    
    # Шаг 3: Заменить SessionGUID
    print("\nШаг 3: Замена SessionGUID...")
    modified_bytes = replace_session_guid(request_bytes, session_guid)
    
    if not modified_bytes:
        print("❌ Не удалось заменить SessionGUID")
        return
    
    # Шаг 4: Отправить запрос
    print("\nШаг 4: Отправка запроса...")
    response = send_raw_request(modified_bytes)
    
    if response and response.status_code == 200:
        print("\n🎉 УСПЕХ! Запрос выполнен успешно!")
        print("Проверьте файлы response.bin и response_decompressed.bin")
    else:
        print("\n❌ Запрос не удался")

if __name__ == '__main__':
    main()