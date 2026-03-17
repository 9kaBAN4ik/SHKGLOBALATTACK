"""
Анализирует настоящие .NET Remoting данные
"""
import struct

def analyze_context_file(filename):
    """Анализирует файл с контекстом"""
    with open(filename, 'rb') as f:
        data = f.read()
    
    print(f"📊 Анализ файла: {filename} ({len(data)} байт)")
    
    # Ищем email
    email_pos = data.find(b'kara.bridges1991@comejoinuspro.org')
    if email_pos != -1:
        print(f"✅ Email найден на позиции {email_pos}")
        
        # Анализируем данные вокруг email
        start = max(0, email_pos - 50)
        end = min(len(data), email_pos + 200)
        
        print(f"\n🔍 Контекст вокруг email (позиции {start}-{end}):")
        
        context = data[start:end]
        
        # Hex dump
        for i in range(0, len(context), 16):
            chunk = context[i:i+16]
            hex_part = ' '.join(f'{b:02X}' for b in chunk)
            ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
            offset = start + i
            print(f"  {offset:08X}: {hex_part:<48} {ascii_part}")
        
        # Анализируем структуру .NET Remoting
        print(f"\n🔍 Анализ .NET Remoting структуры:")
        
        # Ищем начало данных (перед email)
        data_start = email_pos - 50
        while data_start > 0 and data[data_start] != 0x15:  # Ищем маркер начала
            data_start -= 1
        
        if data_start > 0:
            print(f"  Возможное начало данных на позиции {data_start}")
            
            # Анализируем байты перед email
            pre_email = data[data_start:email_pos]
            print(f"  Данные перед email ({len(pre_email)} байт):")
            
            for i in range(0, min(50, len(pre_email)), 16):
                chunk = pre_email[i:i+16]
                hex_part = ' '.join(f'{b:02X}' for b in chunk)
                ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
                print(f"    {i:04X}: {hex_part:<48} {ascii_part}")
        
        # Ищем GUID после email
        guid1_pos = data.find(b'5dbaf401-9e90-4640-9f8f-eb3b55c10137', email_pos)
        guid2_pos = data.find(b'7733c7c0-8f1a-4299-8fdb-d1823dc87dbd', email_pos)
        
        if guid1_pos != -1:
            print(f"\n✅ UserGUID найден на позиции {guid1_pos}")
            
            # Анализируем байты между email и GUID
            between = data[email_pos + 35:guid1_pos]  # 35 = длина email
            print(f"  Байты между email и UserGUID ({len(between)} байт): {between.hex()}")
        
        if guid2_pos != -1:
            print(f"✅ SessionGUID найден на позиции {guid2_pos}")
            
            # Анализируем байты между GUID
            if guid1_pos != -1:
                between_guids = data[guid1_pos + 36:guid2_pos]  # 36 = длина GUID
                print(f"  Байты между GUID ({len(between_guids)} байт): {between_guids.hex()}")
        
        # Анализируем данные после второго GUID
        if guid2_pos != -1:
            after_guid2 = data[guid2_pos + 36:guid2_pos + 100]
            print(f"\n  Данные после SessionGUID ({len(after_guid2)} байт):")
            
            for i in range(0, min(64, len(after_guid2)), 16):
                chunk = after_guid2[i:i+16]
                hex_part = ' '.join(f'{b:02X}' for b in chunk)
                ascii_part = ''.join(chr(b) if 32 <= b <= 126 else '.' for b in chunk)
                print(f"    {i:04X}: {hex_part:<48} {ascii_part}")
        
        # Пытаемся найти параметры LoginUserGuid
        print(f"\n🔍 Поиск параметров LoginUserGuid:")
        
        # Ищем булевые значения (true/false для needVillageData)
        print("  Возможные булевые значения:")
        for i in range(max(0, email_pos - 100), min(len(data), email_pos + 300)):
            if data[i] == 0x01:
                print(f"    TRUE (0x01) на позиции {i}")
            elif data[i] == 0x00 and i > 0 and data[i-1] != 0x00:
                print(f"    FALSE (0x00) на позиции {i}")
        
        # Ищем числа (versionID)
        print("  Возможные числовые значения:")
        for i in range(max(0, email_pos - 100), min(len(data), email_pos + 300)):
            if i + 4 <= len(data):
                try:
                    # Пробуем как int32
                    value = struct.unpack('<I', data[i:i+4])[0]
                    if 0 <= value <= 10:  # Разумные значения для versionID
                        print(f"    INT32 {value} на позиции {i}")
                except:
                    pass

def main():
    print("="*60)
    print("АНАЛИЗ НАСТОЯЩИХ .NET REMOTING ДАННЫХ")
    print("="*60)
    print()
    
    # Анализируем файл с контекстом
    context_files = ['context_135450.bin', 'context_135486.bin', 'context_135524.bin']
    
    for filename in context_files:
        try:
            print(f"\n{'='*60}")
            print(f"ФАЙЛ: {filename}")
            print(f"{'='*60}")
            
            analyze_context_file(filename)
        except FileNotFoundError:
            print(f"❌ Файл {filename} не найден")
        except Exception as e:
            print(f"❌ Ошибка анализа {filename}: {e}")

if __name__ == '__main__':
    main()