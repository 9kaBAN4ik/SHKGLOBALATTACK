"""
Анализ захваченного трафика Stronghold Kingdoms
Помогает понять, что отправляет оригинальная игра
"""
import gzip
import struct
import sys
import os

def analyze_binary_file(filename):
    """Анализирует бинарный файл с захваченным запросом"""
    if not os.path.exists(filename):
        print(f"❌ Файл {filename} не найден")
        return
    
    with open(filename, 'rb') as f:
        data = f.read()
    
    print(f"📊 Анализ файла: {filename}")
    print(f"Размер: {len(data)} байт")
    print()
    
    # Проверяем GZIP
    if len(data) >= 2 and data[0] == 0x1F and data[1] == 0x8B:
        print("✅ Данные сжаты GZIP")
        try:
            decompressed = gzip.decompress(data)
            print(f"Размер после распаковки: {len(decompressed)} байт")
            print()
            analyze_remoting_data(decompressed)
        except Exception as e:
            print(f"❌ Ошибка распаковки: {e}")
    else:
        print("ℹ️ Данные не сжаты (или это не GZIP)")
        print()
        analyze_remoting_data(data)

def analyze_remoting_data(data):
    """Анализирует .NET Remoting бинарные данные"""
    print("🔍 Анализ .NET Remoting данных:")
    print()
    
    # Первые 20 байт в hex
    print("Первые 20 байт (hex):")
    hex_str = ' '.join(f'{b:02X}' for b in data[:20])
    print(f"  {hex_str}")
    print()
    
    # Ищем строки (ASCII)
    print("Найденные ASCII строки (длина > 4):")
    current_str = ""
    for byte in data:
        if 32 <= byte <= 126:  # Printable ASCII
            current_str += chr(byte)
        else:
            if len(current_str) > 4:
                print(f"  '{current_str}'")
            current_str = ""
    if len(current_str) > 4:
        print(f"  '{current_str}'")
    print()
    
    # Ищем Unicode строки
    print("Поиск Unicode строк:")
    try:
        # Пробуем найти LoginUserGuid
        if b'LoginUserGuid' in data:
            idx = data.index(b'LoginUserGuid')
            print(f"  ✅ Найдено 'LoginUserGuid' на позиции {idx}")
            
            # Показываем контекст
            start = max(0, idx - 20)
            end = min(len(data), idx + 50)
            context = data[start:end]
            print(f"  Контекст (hex): {' '.join(f'{b:02X}' for b in context)}")
        else:
            print("  ❌ 'LoginUserGuid' не найдено")
        
        # Ищем GUID паттерны (32 hex символа)
        import re
        text = data.decode('latin-1')
        guids = re.findall(r'[0-9a-f]{32}', text, re.IGNORECASE)
        if guids:
            print(f"\n  Найдены GUID-подобные строки:")
            for guid in guids[:5]:  # Первые 5
                print(f"    {guid}")
    except:
        pass
    
    print()
    
    # Сохраняем в файл для детального анализа
    with open('capture_analysis.hex', 'w') as f:
        f.write("HEX DUMP:\n")
        for i in range(0, len(data), 16):
            chunk = data[i:i+16]
            hex_part = ' '.join(f'{b:02X}' for b in chunk)
            ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
            f.write(f"{i:08X}  {hex_part:<48}  {ascii_part}\n")
    
    print("✅ Детальный hex dump сохранен в capture_analysis.hex")

def compare_with_our_request():
    """Сравнивает захваченный запрос с нашим"""
    print("\n" + "="*60)
    print("СРАВНЕНИЕ С НАШИМ ЗАПРОСОМ")
    print("="*60 + "\n")
    
    # Наш запрос (из SimpleGameClient)
    print("Наш запрос отправляет:")
    print("  userName: kara.bridges1991@comejoinuspro.org")
    print("  userGuid: 5dbaf4019e9046409f8feb3b55c10137")
    print("  sessionGuid: (получен через XML-RPC)")
    print("  needVillageData: true")
    print("  versionID: 1")
    print()
    
    print("Проверь в захваченном трафике:")
    print("  1. Совпадает ли userName?")
    print("  2. Совпадает ли userGuid?")
    print("  3. Совпадает ли sessionGuid?")
    print("  4. Какое значение needVillageData?")
    print("  5. Какое значение versionID?")
    print()
    
    print("Также проверь:")
    print("  - Есть ли другие методы перед LoginUserGuid?")
    print("  - Какие HTTP заголовки используются?")
    print("  - Размер запроса (наш: ~219 байт сжатый)")

def main():
    print("="*60)
    print("АНАЛИЗАТОР ТРАФИКА STRONGHOLD KINGDOMS")
    print("="*60)
    print()
    
    # Проверяем наличие файлов
    files_to_check = [
        'request.bin',
        'wireshark_capture.bin',
        'game_request.bin',
        'capture.bin'
    ]
    
    found_files = [f for f in files_to_check if os.path.exists(f)]
    
    if not found_files:
        print("❌ Не найдены файлы с захваченными данными")
        print()
        print("Ожидаемые имена файлов:")
        for f in files_to_check:
            print(f"  - {f}")
        print()
        print("Инструкция:")
        print("1. Запусти Wireshark")
        print("2. Захвати трафик игры")
        print("3. Найди пакет с LoginUserGuid")
        print("4. Export Packet Bytes → сохрани как request.bin")
        print("5. Запусти этот скрипт снова")
        print()
        print("Подробная инструкция в WIRESHARK_GUIDE.md")
        return
    
    print(f"✅ Найдено файлов: {len(found_files)}")
    print()
    
    for filename in found_files:
        analyze_binary_file(filename)
        print("\n" + "="*60 + "\n")
    
    compare_with_our_request()

if __name__ == '__main__':
    main()
