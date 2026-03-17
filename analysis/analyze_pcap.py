"""
Анализ pcapng файла с захваченным трафиком Stronghold Kingdoms
"""
import os
import gzip
import struct
import re

def find_pcap_files():
    """Находит pcap/pcapng файлы в проекте"""
    files = []
    for filename in os.listdir('.'):
        if filename.endswith(('.pcap', '.pcapng', '.cap')):
            files.append(filename)
    return files

def analyze_with_tshark(filename):
    """Анализирует pcap файл через tshark (если установлен)"""
    import subprocess
    
    try:
        # Экспортируем HTTP запросы
        cmd = [
            'tshark', 
            '-r', filename,
            '-Y', 'http.request.method == "POST"',
            '-T', 'fields',
            '-e', 'frame.number',
            '-e', 'http.request.uri',
            '-e', 'http.content_length',
            '-e', 'frame.len'
        ]
        
        result = subprocess.run(cmd, capture_output=True, text=True)
        
        if result.returncode == 0:
            print("✅ Найдены POST запросы:")
            lines = result.stdout.strip().split('\n')
            for line in lines:
                if line:
                    parts = line.split('\t')
                    if len(parts) >= 4:
                        frame_num, uri, content_len, frame_len = parts[:4]
                        print(f"  Пакет #{frame_num}: {uri} (размер: {frame_len} байт)")
            return True
        else:
            print("❌ tshark не найден или ошибка выполнения")
            return False
            
    except FileNotFoundError:
        print("❌ tshark не установлен")
        return False

def try_pyshark_analysis(filename):
    """Пробует анализ через pyshark"""
    try:
        import pyshark
        
        print(f"📊 Анализ {filename} через pyshark...")
        
        cap = pyshark.FileCapture(filename, display_filter='http.request.method == "POST"')
        
        post_requests = []
        
        for packet in cap:
            try:
                if hasattr(packet, 'http'):
                    http = packet.http
                    if hasattr(http, 'request_uri') and 'Kingdoms.rem' in http.request_uri:
                        post_requests.append({
                            'number': packet.number,
                            'uri': http.request_uri,
                            'length': len(packet),
                            'packet': packet
                        })
            except:
                continue
        
        cap.close()
        
        print(f"✅ Найдено {len(post_requests)} POST запросов к Kingdoms.rem")
        
        for req in post_requests:
            print(f"\n📦 Пакет #{req['number']}: {req['uri']} ({req['length']} байт)")
            
            # Пробуем извлечь данные
            try:
                packet = req['packet']
                if hasattr(packet, 'data'):
                    data = bytes.fromhex(packet.data.data.replace(':', ''))
                    analyze_binary_data(data, f"packet_{req['number']}")
            except Exception as e:
                print(f"  ❌ Ошибка извлечения данных: {e}")
        
        return len(post_requests) > 0
        
    except ImportError:
        print("❌ pyshark не установлен")
        return False
    except Exception as e:
        print(f"❌ Ошибка pyshark: {e}")
        return False

def analyze_binary_data(data, name):
    """Анализирует бинарные данные пакета"""
    print(f"\n🔍 Анализ {name}:")
    print(f"  Размер: {len(data)} байт")
    
    # Проверяем на GZIP
    if len(data) >= 2 and data[0] == 0x1F and data[1] == 0x8B:
        print("  ✅ Данные сжаты GZIP")
        try:
            decompressed = gzip.decompress(data)
            print(f"  Размер после распаковки: {len(decompressed)} байт")
            analyze_remoting_data(decompressed, name + "_decompressed")
        except Exception as e:
            print(f"  ❌ Ошибка распаковки: {e}")
    else:
        print("  ℹ️ Данные не сжаты")
        analyze_remoting_data(data, name)

def analyze_remoting_data(data, name):
    """Анализирует .NET Remoting данные"""
    print(f"\n🔍 .NET Remoting анализ {name}:")
    
    # Ищем строки
    strings = []
    current_str = ""
    
    for byte in data:
        if 32 <= byte <= 126:  # Printable ASCII
            current_str += chr(byte)
        else:
            if len(current_str) > 3:
                strings.append(current_str)
            current_str = ""
    
    if len(current_str) > 3:
        strings.append(current_str)
    
    print(f"  Найдено строк: {len(strings)}")
    
    # Ищем ключевые строки
    key_strings = []
    for s in strings:
        if any(keyword in s.lower() for keyword in ['login', 'guid', 'user', 'session', 'village']):
            key_strings.append(s)
    
    if key_strings:
        print("  🔑 Ключевые строки:")
        for s in key_strings[:10]:  # Первые 10
            print(f"    '{s}'")
    
    # Ищем GUID паттерны
    text = ''.join(chr(b) if 32 <= b <= 126 else ' ' for b in data)
    guids = re.findall(r'[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}', text, re.IGNORECASE)
    
    if guids:
        print("  🆔 Найдены GUID:")
        for guid in guids[:5]:
            print(f"    {guid}")
    
    # Сохраняем в файл
    with open(f'{name}_analysis.txt', 'w', encoding='utf-8') as f:
        f.write(f"Анализ {name}\n")
        f.write(f"Размер: {len(data)} байт\n\n")
        f.write("Строки:\n")
        for s in strings:
            f.write(f"  {s}\n")
        f.write("\nGUID:\n")
        for guid in guids:
            f.write(f"  {guid}\n")
    
    print(f"  ✅ Детальный анализ сохранен в {name}_analysis.txt")

def manual_hex_analysis(filename):
    """Ручной анализ через hex dump"""
    print(f"\n🔧 Ручной анализ {filename}...")
    
    try:
        with open(filename, 'rb') as f:
            data = f.read()
        
        print(f"Размер файла: {len(data)} байт")
        
        # Ищем HTTP заголовки
        text = data.decode('latin-1', errors='ignore')
        
        # Ищем POST запросы
        post_positions = []
        pos = 0
        while True:
            pos = text.find('POST /KingdomsRPC/Kingdoms.rem', pos)
            if pos == -1:
                break
            post_positions.append(pos)
            pos += 1
        
        print(f"✅ Найдено {len(post_positions)} POST запросов")
        
        for i, pos in enumerate(post_positions[:5]):  # Первые 5
            print(f"\n📦 POST запрос #{i+1} на позиции {pos}:")
            
            # Извлекаем контекст
            start = max(0, pos - 100)
            end = min(len(text), pos + 2000)
            context = text[start:end]
            
            # Ищем Content-Length
            content_length_match = re.search(r'Content-Length:\s*(\d+)', context)
            if content_length_match:
                content_length = int(content_length_match.group(1))
                print(f"  Content-Length: {content_length}")
                
                # Ищем начало тела запроса (после двойного \r\n)
                body_start = context.find('\r\n\r\n')
                if body_start != -1:
                    body_start += 4
                    body_data = data[start + body_start:start + body_start + content_length]
                    
                    print(f"  Размер тела: {len(body_data)} байт")
                    analyze_binary_data(body_data, f"post_request_{i+1}")
        
        return len(post_positions) > 0
        
    except Exception as e:
        print(f"❌ Ошибка ручного анализа: {e}")
        return False

def main():
    print("="*60)
    print("АНАЛИЗАТОР PCAP ФАЙЛОВ STRONGHOLD KINGDOMS")
    print("="*60)
    print()
    
    # Ищем pcap файлы
    pcap_files = find_pcap_files()
    
    if not pcap_files:
        print("❌ Не найдены pcap/pcapng файлы в текущей папке")
        print("\nОжидаемые файлы:")
        print("  - game_capture.pcapng")
        print("  - wireshark_capture.pcap")
        print("  - *.pcap, *.pcapng")
        return
    
    print(f"✅ Найдено файлов: {len(pcap_files)}")
    for f in pcap_files:
        print(f"  - {f}")
    print()
    
    # Анализируем каждый файл
    for filename in pcap_files:
        print(f"\n{'='*60}")
        print(f"АНАЛИЗ ФАЙЛА: {filename}")
        print(f"{'='*60}")
        
        # Пробуем разные методы анализа
        success = False
        
        # Метод 1: tshark
        if analyze_with_tshark(filename):
            success = True
        
        # Метод 2: pyshark
        elif try_pyshark_analysis(filename):
            success = True
        
        # Метод 3: ручной анализ
        elif manual_hex_analysis(filename):
            success = True
        
        if not success:
            print("❌ Не удалось проанализировать файл")
            print("\nУстанови дополнительные инструменты:")
            print("  pip install pyshark")
            print("  или установи Wireshark с tshark")

if __name__ == '__main__':
    main()