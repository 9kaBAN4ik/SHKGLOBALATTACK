"""
Читает координаты деревень из памяти запущенного процесса Stronghold Kingdoms
Этот подход обходит проблему с .NET Remoting
"""
import ctypes
import ctypes.wintypes
import psutil
import struct
import json
import time

# Windows API константы
PROCESS_VM_READ = 0x0010
PROCESS_QUERY_INFORMATION = 0x0400

# Windows API функции
kernel32 = ctypes.windll.kernel32
OpenProcess = kernel32.OpenProcess
ReadProcessMemory = kernel32.ReadProcessMemory
CloseHandle = kernel32.CloseHandle

class GameMemoryReader:
    def __init__(self):
        self.process = None
        self.handle = None
    
    def find_game_process(self):
        """Находит процесс Stronghold Kingdoms"""
        for proc in psutil.process_iter(['pid', 'name']):
            try:
                # Ищем процесс игры
                if 'stronghold' in proc.info['name'].lower() or 'shk' in proc.info['name'].lower():
                    print(f"✅ Найден процесс: {proc.info['name']} (PID: {proc.info['pid']})")
                    self.process = proc
                    return True
            except (psutil.NoSuchProcess, psutil.AccessDenied):
                pass
        
        print("❌ Процесс игры не найден")
        print("Запустите Stronghold Kingdoms и войдите в мир")
        return False
    
    def open_process(self):
        """Открывает процесс для чтения памяти"""
        if not self.process:
            return False
        
        self.handle = OpenProcess(
            PROCESS_VM_READ | PROCESS_QUERY_INFORMATION,
            False,
            self.process.info['pid']
        )
        
        if not self.handle:
            print(f"❌ Не удалось открыть процесс (код ошибки: {ctypes.get_last_error()})")
            return False
        
        print(f"✅ Процесс открыт (handle: {self.handle})")
        return True
    
    def read_memory(self, address, size):
        """Читает память процесса"""
        buffer = ctypes.create_string_buffer(size)
        bytes_read = ctypes.c_size_t(0)
        
        success = ReadProcessMemory(
            self.handle,
            ctypes.c_void_p(address),
            buffer,
            size,
            ctypes.byref(bytes_read)
        )
        
        if not success:
            return None
        
        return buffer.raw[:bytes_read.value]
    
    def scan_for_pattern(self, pattern, start_address=0x00400000, end_address=0x7FFFFFFF, chunk_size=4096):
        """
        Сканирует память в поисках паттерна
        Это медленный процесс, используйте только для поиска сигнатур
        """
        print(f"Сканирование памяти от 0x{start_address:X} до 0x{end_address:X}...")
        print("Это может занять несколько минут...")
        
        matches = []
        current_address = start_address
        
        while current_address < end_address:
            data = self.read_memory(current_address, chunk_size)
            
            if data:
                # Ищем паттерн в прочитанных данных
                offset = data.find(pattern)
                if offset != -1:
                    match_address = current_address + offset
                    matches.append(match_address)
                    print(f"  Найдено совпадение по адресу: 0x{match_address:X}")
            
            current_address += chunk_size
            
            # Показываем прогресс каждые 10MB
            if (current_address - start_address) % (10 * 1024 * 1024) == 0:
                progress = ((current_address - start_address) / (end_address - start_address)) * 100
                print(f"  Прогресс: {progress:.1f}%")
        
        return matches
    
    def find_village_data(self):
        """
        Пытается найти данные о деревнях в памяти
        
        Стратегия:
        1. Ищем известные ID деревень (если есть)
        2. Ищем паттерны координат (обычно хранятся как int32)
        3. Ищем строки с названиями деревень
        """
        print("\n=== Поиск данных о деревнях ===\n")
        
        # TODO: Нужно знать хотя бы один ID деревни для поиска
        # Или использовать Cheat Engine для поиска значений
        
        print("Для поиска данных нужно:")
        print("1. Открыть игру и войти в мир")
        print("2. Узнать ID хотя бы одной деревни")
        print("3. Использовать Cheat Engine для поиска этого ID в памяти")
        print("4. Найти структуру данных, содержащую ID, X, Y, Name")
        print("5. Вернуться сюда с адресом структуры")
        
        return None
    
    def close(self):
        """Закрывает handle процесса"""
        if self.handle:
            CloseHandle(self.handle)
            self.handle = None

def main():
    print("=== Stronghold Kingdoms Memory Reader ===\n")
    
    reader = GameMemoryReader()
    
    # Шаг 1: Найти процесс игры
    if not reader.find_game_process():
        print("\nЗапустите игру и попробуйте снова")
        return
    
    # Шаг 2: Открыть процесс
    if not reader.open_process():
        print("\nНе удалось открыть процесс")
        print("Попробуйте запустить скрипт от имени администратора")
        return
    
    try:
        # Шаг 3: Найти данные о деревнях
        villages = reader.find_village_data()
        
        if villages:
            # Сохраняем в JSON
            with open('villages.json', 'w', encoding='utf-8') as f:
                json.dump(villages, f, indent=2, ensure_ascii=False)
            
            print(f"\n✅ Найдено деревень: {len(villages)}")
            print("✅ Данные сохранены в villages.json")
        else:
            print("\n⚠️ Данные не найдены")
            print("\nИспользуйте Cheat Engine для поиска адресов:")
            print("1. Откройте Cheat Engine")
            print("2. Подключитесь к процессу игры")
            print("3. Найдите ID деревни (тип: 4 bytes)")
            print("4. Найдите координаты X и Y рядом с ID")
            print("5. Запишите адреса и обновите этот скрипт")
    
    finally:
        reader.close()

if __name__ == '__main__':
    main()
