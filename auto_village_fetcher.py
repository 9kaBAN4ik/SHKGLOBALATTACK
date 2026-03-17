"""
Автоматический получатель координат деревень
Запускает игру и читает координаты из памяти процесса
"""
import subprocess
import time
import psutil
import ctypes
import ctypes.wintypes
import struct
import json
import requests
import os
from dotenv import load_dotenv

# Windows API
PROCESS_VM_READ = 0x0010
PROCESS_QUERY_INFORMATION = 0x0400
kernel32 = ctypes.windll.kernel32

class VillageFetcher:
    def __init__(self):
        self.process = None
        self.handle = None
        
    def start_game_if_needed(self):
        """Запускает игру если она не запущена"""
        # Проверяем, запущена ли игра
        for proc in psutil.process_iter(['pid', 'name']):
            try:
                if 'stronghold' in proc.info['name'].lower():
                    print(f"✅ Игра уже запущена: {proc.info['name']} (PID: {proc.info['pid']})")
                    return True
            except:
                pass
        
        print("🎮 Игра не запущена. Запускаю автоматически...")
        
        # Пути где может быть игра
        game_paths = [
            r"C:\Program Files (x86)\Firefly Studios\Stronghold Kingdoms\StrongholdKingdoms.exe",
            r"C:\Program Files\Firefly Studios\Stronghold Kingdoms\StrongholdKingdoms.exe",
            r"C:\Games\Stronghold Kingdoms\StrongholdKingdoms.exe"
        ]
        
        for path in game_paths:
            if os.path.exists(path):
                try:
                    subprocess.Popen([path])
                    print(f"✅ Игра запущена: {path}")
                    print("⏳ Жду 30 секунд для загрузки...")
                    time.sleep(30)
                    return True
                except Exception as e:
                    print(f"❌ Ошибка запуска {path}: {e}")
        
        print("❌ Не удалось найти или запустить игру")
        print("Запустите игру вручную и войдите в мир Europa 10")
        return False
    
    def find_game_process(self):
        """Находит процесс игры"""
        for proc in psutil.process_iter(['pid', 'name', 'exe']):
            try:
                name = proc.info['name'].lower()
                if 'stronghold' in name or 'shk' in name:
                    self.process = proc
                    print(f"✅ Найден процесс игры: {proc.info['name']} (PID: {proc.info['pid']})")
                    return True
            except:
                pass
        
        print("❌ Процесс игры не найден")
        return False
    
    def open_process(self):
        """Открывает процесс для чтения памяти"""
        if not self.process:
            return False
        
        self.handle = kernel32.OpenProcess(
            PROCESS_VM_READ | PROCESS_QUERY_INFORMATION,
            False,
            self.process.info['pid']
        )
        
        if not self.handle:
            print(f"❌ Не удалось открыть процесс")
            return False
        
        return True
    
    def read_memory(self, address, size):
        """Читает память процесса"""
        buffer = ctypes.create_string_buffer(size)
        bytes_read = ctypes.c_size_t(0)
        
        success = kernel32.ReadProcessMemory(
            self.handle,
            ctypes.c_void_p(address),
            buffer,
            size,
            ctypes.byref(bytes_read)
        )
        
        if success:
            return buffer.raw[:bytes_read.value]
        return None
    
    def scan_for_villages(self):
        """Сканирует память в поисках координат деревень"""
        print("🔍 Сканирование памяти в поисках координат деревень...")
        print("Это может занять несколько минут...")
        
        villages = []
        
        # Получаем информацию о памяти процесса
        try:
            memory_info = self.process.memory_info()
            print(f"Размер памяти процесса: {memory_info.rss // 1024 // 1024} MB")
        except:
            pass
        
        # Сканируем основные области памяти
        start_address = 0x00400000  # Начало пользовательского пространства
        end_address = 0x7FFFFFFF    # Конец пользовательского пространства
        chunk_size = 4096           # Размер блока для чтения
        
        current_address = start_address
        scanned_mb = 0
        
        while current_address < end_address:
            data = self.read_memory(current_address, chunk_size)
            
            if data:
                # Ищем паттерны координат
                found_villages = self.find_village_patterns(data, current_address)
                villages.extend(found_villages)
            
            current_address += chunk_size
            scanned_mb += chunk_size // 1024 // 1024
            
            # Показываем прогресс каждые 100MB
            if scanned_mb % 100 == 0 and scanned_mb > 0:
                print(f"  Просканировано: {scanned_mb} MB, найдено деревень: {len(villages)}")
            
            # Ограничиваем сканирование (не более 2GB)
            if scanned_mb > 2000:
                break
        
        # Убираем дубликаты
        unique_villages = []
        seen_coords = set()
        
        for village in villages:
            coord_key = (village['x'], village['y'])
            if coord_key not in seen_coords:
                seen_coords.add(coord_key)
                unique_villages.append(village)
        
        print(f"✅ Найдено уникальных деревень: {len(unique_villages)}")
        return unique_villages
    
    def find_village_patterns(self, data, base_address):
        """Ищет паттерны координат деревень в данных"""
        villages = []
        
        # Ищем структуры, которые могут содержать координаты
        for i in range(0, len(data) - 12, 4):
            try:
                # Читаем 3 int32 подряд (возможно ID, X, Y)
                val1 = struct.unpack('<I', data[i:i+4])[0]
                val2 = struct.unpack('<I', data[i+4:i+8])[0]
                val3 = struct.unpack('<I', data[i+8:i+12])[0]
                
                # Проверяем, похоже ли на координаты деревни
                if self.looks_like_village_coords(val1, val2, val3):
                    village = {
                        'id': val1,
                        'x': val2,
                        'y': val3,
                        'name': f'Village_{val1}',
                        'address': base_address + i
                    }
                    villages.append(village)
                    
            except:
                continue
        
        return villages
    
    def looks_like_village_coords(self, id_val, x_val, y_val):
        """Проверяет, похожи ли значения на координаты деревни"""
        # ID деревни обычно больше 10000
        if id_val < 10000 or id_val > 999999999:
            return False
        
        # Координаты обычно в диапазоне 0-1000
        if x_val < 0 or x_val > 1000:
            return False
        
        if y_val < 0 or y_val > 1000:
            return False
        
        # Дополнительные проверки
        # Координаты не должны быть слишком маленькими
        if x_val < 10 or y_val < 10:
            return False
        
        return True
    
    def send_to_proxy_server(self, villages):
        """Отправляет координаты в прокси-сервер"""
        if not villages:
            return 0
        
        print(f"📤 Отправка {len(villages)} деревень в прокси-сервер...")
        
        success_count = 0
        
        try:
            for village in villages:
                data = {
                    "id": village['id'],
                    "x": village['x'],
                    "y": village['y'],
                    "name": village['name']
                }
                
                response = requests.post(
                    "http://localhost:5000/api/village",
                    json=data,
                    timeout=5
                )
                
                if response.status_code == 200:
                    success_count += 1
                
        except Exception as e:
            print(f"❌ Ошибка отправки в прокси-сервер: {e}")
        
        print(f"✅ Отправлено успешно: {success_count}/{len(villages)}")
        return success_count
    
    def save_to_file(self, villages):
        """Сохраняет координаты в файл"""
        if not villages:
            return
        
        with open('villages.json', 'w', encoding='utf-8') as f:
            json.dump(villages, f, indent=2, ensure_ascii=False)
        
        print(f"✅ Координаты сохранены в villages.json")
    
    def close(self):
        """Закрывает handle процесса"""
        if self.handle:
            kernel32.CloseHandle(self.handle)

def main():
    print("="*60)
    print("АВТОМАТИЧЕСКИЙ ПОЛУЧАТЕЛЬ КООРДИНАТ ДЕРЕВЕНЬ")
    print("="*60)
    print()
    
    fetcher = VillageFetcher()
    
    try:
        # Шаг 1: Запустить игру если нужно
        if not fetcher.start_game_if_needed():
            print("\n❌ Не удалось запустить игру")
            print("Запустите игру вручную, войдите в мир Europa 10 и запустите скрипт снова")
            return
        
        # Шаг 2: Найти процесс игры
        if not fetcher.find_game_process():
            print("\n❌ Процесс игры не найден")
            return
        
        # Шаг 3: Открыть процесс
        if not fetcher.open_process():
            print("\n❌ Не удалось открыть процесс")
            print("Попробуйте запустить скрипт от имени администратора")
            return
        
        # Шаг 4: Сканировать память
        villages = fetcher.scan_for_villages()
        
        if not villages:
            print("\n❌ Координаты деревень не найдены")
            print("Убедитесь что:")
            print("1. Игра запущена и вы вошли в мир")
            print("2. Карта загружена (видны деревни)")
            print("3. Скрипт запущен от имени администратора")
            return
        
        # Шаг 5: Сохранить результаты
        fetcher.save_to_file(villages)
        
        # Шаг 6: Отправить в прокси-сервер
        success_count = fetcher.send_to_proxy_server(villages)
        
        print(f"\n🎉 ГОТОВО!")
        print(f"Найдено деревень: {len(villages)}")
        print(f"Отправлено в бота: {success_count}")
        print(f"Файл: villages.json")
        
        # Показываем примеры
        print(f"\nПримеры найденных деревень:")
        for village in villages[:5]:
            print(f"  ID: {village['id']}, X: {village['x']}, Y: {village['y']}")
        
        print(f"\nТеперь можно использовать команды бота:")
        print(f"!time capx4 {villages[0]['id']}[1] {villages[1]['id'] if len(villages) > 1 else villages[0]['id']}")
        
    finally:
        fetcher.close()

if __name__ == '__main__':
    main()