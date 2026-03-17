"""
Глубокий анализ pcap файла - ищет текстовые данные в разных форматах
"""
import os
import re
import struct

def extract_post_requests(filename):
    """Извлекает все POST запросы из pcap файла"""
    with open(filename, 'rb') as f:
        data = f.read()
    
    # Конвертируем в текст для поиска HTTP заголовков
    text = data.decode('latin-1', errors='ignore')
    
    requests = []
    pos = 0
    
    while True:
        # Ищем POST запрос
        post_pos = text.find('POST /KingdomsRPC/Kingdoms.rem', pos)
        if post_pos == -1:
            break
        
        # Ищем Content-Length
        content_length_match = re.search(r'Content-Length:\s*(\d+)', text[post_pos:post_pos+500])
        if content_length_match:
            content_length = int(content_length_match.group(1))
            
            # Ищем начало тела запроса
            headers_end = text.find('\r\n\r\n', post_pos)
            if headers_end != -1:
                body_start = headers_end + 4
                body_data = data[body_start:body_start + content_length]
                
                requests.append({
                    'position': post_pos,
                    'content_length': content_length,
                    'body': body_data
                })
        
        pos = post_pos + 1
    
    return requests

def analyze_binary_deeply(data, name):
    """Глубокий анализ бинарных данных"""
    print(f"\n🔍 Глубокий анализ {name} ({len(data)} байт):")
    
    # Hex dump первых 100 байт
    print("  Hex dump (первые 100 байт):")
    for i in range(0, min(100, len(data)), 16):
        chunk = data[i:i+16]
        hex_part = ' '.join(f'{b:02X}' for b in chunk)
        ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
        print(f"    {i:04X}: {hex_part:<48} {ascii_part}")
    
    # Ищем строки в разных кодировках
    print("\n  🔤 Поиск строк:")
    
    # ASCII строки
    ascii_strings = find_strings(data, encoding='ascii')
    if ascii_strings:
        print(f"    ASCII строки ({len(ascii_strings)}):")
        for s in ascii_strings[:10]:
            print(f"      '{s}'")
    
    # UTF-8 строки
    utf8_strings = find_strings(data, encoding='utf-8')
    if utf8_strings:
        print(f"    UTF-8 строки ({len(utf8_strings)}):")
        for s in utf8_strings[:10]:
            print(f"      '{s}'")
    
    # UTF-16 строки (часто используется в .NET)
    utf16_strings = find_utf16_strings(data)
    if utf16_strings:
        print(f"    UTF-16 строки ({len(utf16_strings)}):")
        for s in utf16_strings[:10]:
            print(f"      '{s}'")
    
    # Ищем GUID паттерны в разных форматах
    print("\n  🆔 Поиск GUID:")
    
    # Стандартный формат GUID
    text_data = data.decode('latin-1', errors='ignore')
    guids = re.findall(r'[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}', text_data, re.IGNORECASE)
    if guids:
        print(f"    Стандартные GUID ({len(guids)}):")
        for guid in guids:
            print(f"      {guid}")
    
    # GUID без дефисов
    guid_nodash = re.findall(r'[0-9a-f]{32}', text_data, re.IGNORECASE)
    if guid_nodash:
        print(f"    GUID без дефисов ({len(guid_nodash)}):")
        for guid in guid_nodash[:5]:
            print(f"      {guid}")
    
    # Бинарные GUID (16 байт)
    binary_guids = find_binary_guids(data)
    if binary_guids:
        print(f"    Бинарные GUID ({len(binary_guids)}):")
        for guid in binary_guids[:5]:
            print(f"      {guid}")
    
    # Ищем email адреса
    emails = re.findall(r'[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}', text_data)
    if emails:
        print(f"\n  📧 Email адреса ({len(emails)}):")
        for email in emails:
            print(f"      {email}")
    
    # Ищем числа (возможно versionID)
    numbers = re.findall(r'\b\d+\b', text_data)
    if numbers:
        unique_numbers = list(set(numbers))[:10]
        print(f"\n  🔢 Числа ({len(unique_numbers)} уникальных):")
        print(f"      {', '.join(unique_numbers)}")
    
    # Сохраняем детальный анализ
    with open(f'{name}_deep_analysis.txt', 'w', encoding='utf-8') as f:
        f.write(f"Глубокий анализ {name}\n")
        f.write(f"Размер: {len(data)} байт\n\n")
        
        f.write("HEX DUMP:\n")
        for i in range(0, len(data), 16):
            chunk = data[i:i+16]
            hex_part = ' '.join(f'{b:02X}' for b in chunk)
            ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
            f.write(f"{i:04X}: {hex_part:<48} {ascii_part}\n")
        
        f.write("\nASCII СТРОКИ:\n")
        for s in ascii_strings:
            f.write(f"  {s}\n")
        
        f.write("\nUTF-16 СТРОКИ:\n")
        for s in utf16_strings:
            f.write(f"  {s}\n")
        
        f.write("\nGUID:\n")
        for guid in guids + guid_nodash:
            f.write(f"  {guid}\n")
        
        f.write("\nEMAIL:\n")
        for email in emails:
            f.write(f"  {email}\n")
    
    print(f"  ✅ Детальный анализ сохранен в {name}_deep_analysis.txt")

def find_strings(data, encoding='ascii', min_length=4):
    """Находит строки в указанной кодировке"""
    strings = []
    current_str = ""
    
    try:
        if encoding == 'ascii':
            for byte in data:
                if 32 <= byte <= 126:  # Printable ASCII
                    current_str += chr(byte)
                else:
                    if len(current_str) >= min_length:
                        strings.append(current_str)
                    current_str = ""
        elif encoding == 'utf-8':
            text = data.decode('utf-8', errors='ignore')
            words = re.findall(r'[a-zA-Z0-9@._-]{4,}', text)
            strings.extend(words)
    except:
        pass
    
    if len(current_str) >= min_length:
        strings.append(current_str)
    
    return list(set(strings))  # Убираем дубликаты

def find_utf16_strings(data, min_length=4):
    """Находит UTF-16 строки (часто используется в .NET)"""
    strings = []
    
    # Пробуем UTF-16 LE
    try:
        for i in range(0, len(data) - 1, 2):
            if i + 1 < len(data):
                # Читаем как UTF-16 LE
                char_bytes = data[i:i+2]
                if len(char_bytes) == 2:
                    char_code = struct.unpack('<H', char_bytes)[0]
                    if 32 <= char_code <= 126:  # Printable ASCII в UTF-16
                        # Ищем строку
                        string_bytes = bytearray()
                        j = i
                        while j < len(data) - 1:
                            char_bytes = data[j:j+2]
                            if len(char_bytes) == 2:
                                char_code = struct.unpack('<H', char_bytes)[0]
                                if 32 <= char_code <= 126:
                                    string_bytes.extend(char_bytes)
                                    j += 2
                                else:
                                    break
                            else:
                                break
                        
                        if len(string_bytes) >= min_length * 2:
                            try:
                                string = string_bytes.decode('utf-16le')
                                if len(string) >= min_length:
                                    strings.append(string)
                            except:
                                pass
    except:
        pass
    
    return list(set(strings))

def find_binary_guids(data):
    """Ищет бинарные GUID (16 байт)"""
    guids = []
    
    for i in range(len(data) - 15):
        guid_bytes = data[i:i+16]
        
        # Проверяем, похоже ли на GUID
        # GUID имеет определенную структуру
        if len(guid_bytes) == 16:
            try:
                # Конвертируем в стандартный формат GUID
                guid_str = f"{guid_bytes[0:4].hex()}-{guid_bytes[4:6].hex()}-{guid_bytes[6:8].hex()}-{guid_bytes[8:10].hex()}-{guid_bytes[10:16].hex()}"
                
                # Проверяем, что это не все нули или все FF
                if not all(b == 0 for b in guid_bytes) and not all(b == 0xFF for b in guid_bytes):
                    guids.append(guid_str)
            except:
                pass
    
    return list(set(guids))[:10]  # Первые 10 уникальных

def main():
    print("="*60)
    print("ГЛУБОКИЙ АНАЛИЗ PCAP ФАЙЛА")
    print("="*60)
    print()
    
    # Ищем pcap файлы
    pcap_files = [f for f in os.listdir('.') if f.endswith(('.pcap', '.pcapng', '.cap'))]
    
    if not pcap_files:
        print("❌ Не найдены pcap файлы")
        return
    
    for filename in pcap_files:
        print(f"📁 Анализ файла: {filename}")
        
        # Извлекаем POST запросы
        requests = extract_post_requests(filename)
        
        print(f"✅ Найдено {len(requests)} POST запросов")
        
        # Анализируем каждый запрос
        for i, req in enumerate(requests[:10]):  # Первые 10
            print(f"\n{'='*40}")
            print(f"POST ЗАПРОС #{i+1}")
            print(f"{'='*40}")
            print(f"Позиция: {req['position']}")
            print(f"Content-Length: {req['content_length']}")
            
            analyze_binary_deeply(req['body'], f"post_{i+1}")

if __name__ == '__main__':
    main()