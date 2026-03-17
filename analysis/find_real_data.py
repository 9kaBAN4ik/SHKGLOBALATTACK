"""
Ищет настоящие данные .NET Remoting в pcap файле
"""
import os
import re

def find_real_remoting_data(filename):
    """Ищет настоящие .NET Remoting данные"""
    with open(filename, 'rb') as f:
        data = f.read()
    
    print(f"📁 Поиск в файле: {filename} ({len(data)} байт)")
    
    # Конвертируем в текст
    text = data.decode('latin-1', errors='ignore')
    
    # Ищем email адрес
    email_pattern = r'kara\.bridges1991@comejoinuspro\.org'
    email_matches = []
    
    for match in re.finditer(email_pattern, text):
        pos = match.start()
        email_matches.append(pos)
        print(f"✅ Найден email на позиции {pos}")
    
    # Ищем GUID паттерны
    guid_pattern = r'[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}'
    guid_matches = []
    
    for match in re.finditer(guid_pattern, text, re.IGNORECASE):
        pos = match.start()
        guid = match.group(0)
        guid_matches.append((pos, guid))
        print(f"✅ Найден GUID на позиции {pos}: {guid}")
    
    # Ищем LoginUserGuid
    login_pattern = r'LoginUserGuid'
    login_matches = []
    
    for match in re.finditer(login_pattern, text):
        pos = match.start()
        login_matches.append(pos)
        print(f"✅ Найден LoginUserGuid на позиции {pos}")
    
    # Анализируем контекст вокруг найденных данных
    all_positions = email_matches + [pos for pos, _ in guid_matches] + login_matches
    
    if all_positions:
        print(f"\n🔍 Анализ контекста:")
        
        for pos in sorted(set(all_positions))[:10]:  # Первые 10 уникальных позиций
            print(f"\n📍 Позиция {pos}:")
            
            # Извлекаем контекст
            start = max(0, pos - 200)
            end = min(len(data), pos + 500)
            context_data = data[start:end]
            
            # Показываем hex dump
            print("  Hex dump:")
            for i in range(0, min(300, len(context_data)), 16):
                chunk = context_data[i:i+16]
                hex_part = ' '.join(f'{b:02X}' for b in chunk)
                ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
                offset = start + i
                print(f"    {offset:08X}: {hex_part:<48} {ascii_part}")
            
            # Ищем строки в контексте
            context_text = context_data.decode('latin-1', errors='ignore')
            
            # Ищем все интересные строки
            interesting_strings = []
            
            # Email
            emails = re.findall(r'[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}', context_text)
            interesting_strings.extend([f"EMAIL: {email}" for email in emails])
            
            # GUID
            guids = re.findall(guid_pattern, context_text, re.IGNORECASE)
            interesting_strings.extend([f"GUID: {guid}" for guid in guids])
            
            # Другие строки
            other_strings = re.findall(r'[a-zA-Z]{4,}', context_text)
            interesting_strings.extend([f"STRING: {s}" for s in other_strings[:5]])
            
            if interesting_strings:
                print("  Найденные данные:")
                for s in interesting_strings[:10]:
                    print(f"    {s}")
            
            # Сохраняем контекст в файл
            with open(f'context_{pos}.bin', 'wb') as f:
                f.write(context_data)
            
            print(f"  ✅ Контекст сохранен в context_{pos}.bin")
    
    else:
        print("❌ Не найдены ожидаемые данные")
        
        # Попробуем поискать другие паттерны
        print("\n🔍 Поиск альтернативных паттернов:")
        
        # Ищем .NET Remoting заголовки
        remoting_patterns = [
            b'.NET',
            b'Remoting',
            b'BinaryFormatter',
            b'LoginUserGuid',
            b'GetVillageNames'
        ]
        
        for pattern in remoting_patterns:
            positions = []
            pos = 0
            while True:
                pos = data.find(pattern, pos)
                if pos == -1:
                    break
                positions.append(pos)
                pos += 1
            
            if positions:
                print(f"  ✅ Найдено {len(positions)} вхождений '{pattern.decode()}': {positions[:5]}")
            else:
                print(f"  ❌ Не найдено '{pattern.decode()}'")

def main():
    print("="*60)
    print("ПОИСК НАСТОЯЩИХ .NET REMOTING ДАННЫХ")
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
        
        find_real_remoting_data(filename)

if __name__ == '__main__':
    main()