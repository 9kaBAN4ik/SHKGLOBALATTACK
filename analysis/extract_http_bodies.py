"""
Извлекает HTTP тела из pcap файла
"""
import os
import re

def extract_http_bodies(filename):
    """Извлекает HTTP POST тела из pcap файла"""
    with open(filename, 'rb') as f:
        data = f.read()
    
    # Конвертируем в текст для поиска HTTP
    text = data.decode('latin-1', errors='ignore')
    
    print(f"📁 Анализ файла: {filename} ({len(data)} байт)")
    
    # Ищем все HTTP POST запросы
    post_pattern = r'POST /KingdomsRPC/Kingdoms\.rem HTTP/1\.1.*?Content-Length:\s*(\d+).*?\r\n\r\n'
    
    matches = []
    for match in re.finditer(post_pattern, text, re.DOTALL):
        content_length = int(match.group(1))
        headers_end = match.end()
        
        # Извлекаем тело запроса
        body_data = data[headers_end:headers_end + content_length]
        
        matches.append({
            'position': match.start(),
            'headers': match.group(0),
            'content_length': content_length,
            'body': body_data
        })
    
    print(f"✅ Найдено {len(matches)} HTTP POST запросов")
    
    return matches

def analyze_http_body(body, name):
    """Анализирует HTTP тело запроса"""
    print(f"\n🔍 Анализ {name} ({len(body)} байт):")
    
    # Hex dump
    print("  Hex dump:")
    for i in range(0, min(200, len(body)), 16):
        chunk = body[i:i+16]
        hex_part = ' '.join(f'{b:02X}' for b in chunk)
        ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
        print(f"    {i:04X}: {hex_part:<48} {ascii_part}")
    
    # Ищем строки
    strings = []
    current_str = ""
    
    for byte in body:
        if 32 <= byte <= 126:  # Printable ASCII
            current_str += chr(byte)
        else:
            if len(current_str) >= 3:
                strings.append(current_str)
            current_str = ""
    
    if len(current_str) >= 3:
        strings.append(current_str)
    
    if strings:
        print(f"\n  📝 ASCII строки ({len(strings)}):")
        for s in strings[:20]:
            print(f"    '{s}'")
    
    # Ищем UTF-16 строки (для .NET)
    utf16_strings = []
    try:
        for i in range(0, len(body) - 1, 2):
            if body[i] != 0 and body[i+1] == 0:  # Возможно UTF-16 LE
                # Читаем строку
                string_chars = []
                j = i
                while j < len(body) - 1:
                    if body[j] != 0 and body[j+1] == 0 and 32 <= body[j] <= 126:
                        string_chars.append(chr(body[j]))
                        j += 2
                    else:
                        break
                
                if len(string_chars) >= 3:
                    utf16_strings.append(''.join(string_chars))
    except:
        pass
    
    if utf16_strings:
        print(f"\n  🔤 UTF-16 строки ({len(utf16_strings)}):")
        for s in utf16_strings[:10]:
            print(f"    '{s}'")
    
    # Ищем GUID паттерны
    text_data = body.decode('latin-1', errors='ignore')
    
    # Стандартные GUID
    guids = re.findall(r'[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}', text_data, re.IGNORECASE)
    if guids:
        print(f"\n  🆔 GUID ({len(guids)}):")
        for guid in guids:
            print(f"    {guid}")
    
    # GUID без дефисов
    guid_nodash = re.findall(r'[0-9a-f]{32}', text_data, re.IGNORECASE)
    if guid_nodash:
        print(f"\n  🆔 GUID без дефисов ({len(guid_nodash)}):")
        for guid in guid_nodash[:5]:
            print(f"    {guid}")
    
    # Email адреса
    emails = re.findall(r'[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}', text_data)
    if emails:
        print(f"\n  📧 Email ({len(emails)}):")
        for email in emails:
            print(f"    {email}")
    
    # Ищем LoginUserGuid
    if 'LoginUserGuid' in text_data:
        print(f"\n  ✅ Найден LoginUserGuid!")
        
        # Ищем контекст вокруг LoginUserGuid
        pos = text_data.find('LoginUserGuid')
        context_start = max(0, pos - 50)
        context_end = min(len(text_data), pos + 100)
        context = text_data[context_start:context_end]
        
        print(f"    Контекст: '{context}'")
    
    # Сохраняем в файл
    with open(f'{name}_http_body.bin', 'wb') as f:
        f.write(body)
    
    with open(f'{name}_analysis.txt', 'w', encoding='utf-8') as f:
        f.write(f"HTTP Body анализ {name}\n")
        f.write(f"Размер: {len(body)} байт\n\n")
        
        f.write("HEX DUMP:\n")
        for i in range(0, len(body), 16):
            chunk = body[i:i+16]
            hex_part = ' '.join(f'{b:02X}' for b in chunk)
            ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
            f.write(f"{i:04X}: {hex_part:<48} {ascii_part}\n")
        
        f.write("\nASCII СТРОКИ:\n")
        for s in strings:
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
    
    print(f"  ✅ Сохранено: {name}_http_body.bin, {name}_analysis.txt")

def main():
    print("="*60)
    print("ИЗВЛЕЧЕНИЕ HTTP ТЕЛА ИЗ PCAP")
    print("="*60)
    print()
    
    # Ищем pcap файлы
    pcap_files = [f for f in os.listdir('.') if f.endswith(('.pcap', '.pcapng', '.cap'))]
    
    if not pcap_files:
        print("❌ Не найдены pcap файлы")
        return
    
    for filename in pcap_files:
        print(f"\n{'='*60}")
        print(f"ФАЙЛ: {filename}")
        print(f"{'='*60}")
        
        # Извлекаем HTTP тела
        http_requests = extract_http_bodies(filename)
        
        # Анализируем каждое тело
        for i, req in enumerate(http_requests[:10]):  # Первые 10
            print(f"\n{'='*40}")
            print(f"HTTP POST #{i+1}")
            print(f"{'='*40}")
            print(f"Позиция: {req['position']}")
            print(f"Content-Length: {req['content_length']}")
            
            # Показываем заголовки
            headers_lines = req['headers'].split('\n')[:5]  # Первые 5 строк
            print("Заголовки:")
            for line in headers_lines:
                if line.strip():
                    print(f"  {line.strip()}")
            
            analyze_http_body(req['body'], f"http_post_{i+1}")

if __name__ == '__main__':
    main()