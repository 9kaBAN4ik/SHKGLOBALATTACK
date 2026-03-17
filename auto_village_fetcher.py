#!/usr/bin/env python3
"""
Автоматический получатель координат деревень из игры Stronghold Kingdoms
Использует GameServerClient.cs для подключения к серверу игры
"""
import subprocess
import json
import os
import sys
from dotenv import load_dotenv

load_dotenv()

class VillageFetcher:
    def __init__(self):
        self.email = os.getenv('SHK_EMAIL')
        self.password = os.getenv('SHK_PASSWORD')
        
        if not self.email or not self.password:
            raise ValueError("SHK_EMAIL and SHK_PASSWORD must be set in .env file")
    
    def fetch_all_villages(self):
        """
        Получить все деревни с игрового сервера
        Возвращает список словарей: [{"id": int, "name": str, "x": int, "y": int}, ...]
        """
        print("🎮 Connecting to Stronghold Kingdoms game server...")
        print(f"📧 Email: {self.email}")
        
        try:
            # Компилируем и запускаем C# приложение
            # Предполагаем что GameServerClient.cs имеет метод Main который:
            # 1. Авторизуется
            # 2. Подключается к игровому серверу
            # 3. Получает список всех деревень
            # 4. Выводит JSON в stdout
            
            # Сначала компилируем
            print("🔨 Compiling GameServerClient...")
            compile_result = subprocess.run(
                ['csc', '/r:ServerInterface.dll', '/r:CustomSinks.dll', 
                 '/r:Newtonsoft.Json.dll', 'GameServerClient.cs'],
                capture_output=True,
                text=True,
                cwd=os.getcwd()
            )
            
            if compile_result.returncode != 0:
                print(f"❌ Compilation failed: {compile_result.stderr}")
                return None
            
            print("✅ Compiled successfully")
            
            # Запускаем
            print("🚀 Running GameServerClient...")
            run_result = subprocess.run(
                ['./GameServerClient.exe'],
                capture_output=True,
                text=True,
                timeout=60,
                env=os.environ.copy()
            )
            
            if run_result.returncode != 0:
                print(f"❌ Execution failed: {run_result.stderr}")
                print(f"Output: {run_result.stdout}")
                return None
            
            print("✅ Game server responded")
            
            # Парсим JSON output
            try:
                villages = json.loads(run_result.stdout)
                print(f"📊 Fetched {len(villages)} villages from game server")
                return villages
            except json.JSONDecodeError as e:
                print(f"❌ Failed to parse JSON: {e}")
                print(f"Output: {run_result.stdout}")
                return None
                
        except subprocess.TimeoutExpired:
            print("❌ Request to game server timed out")
            return None
        except Exception as e:
            print(f"❌ Error: {e}")
            return None
    
    def fetch_specific_villages(self, village_ids):
        """
        Получить конкретные деревни по их ID
        """
        all_villages = self.fetch_all_villages()
        
        if all_villages is None:
            return None
        
        # Фильтруем только нужные деревни
        filtered = [v for v in all_villages if v['id'] in village_ids]
        
        print(f"🎯 Found {len(filtered)}/{len(village_ids)} requested villages")
        
        return filtered
    
    def send_to_proxy(self, villages):
        """
        Отправить полученные деревни в прокси-сервер
        """
        import requests
        
        print(f"📤 Sending {len(villages)} villages to proxy server...")
        
        success_count = 0
        for village in villages:
            try:
                response = requests.post(
                    'http://localhost:5000/api/village',
                    json={
                        'id': village['id'],
                        'x': village['x'],
                        'y': village['y'],
                        'name': village['name']
                    },
                    timeout=5
                )
                
                if response.status_code == 200:
                    success_count += 1
                else:
                    print(f"⚠️ Failed to cache village {village['id']}: {response.status_code}")
            except Exception as e:
                print(f"⚠️ Error caching village {village['id']}: {e}")
        
        print(f"✅ Successfully cached {success_count}/{len(villages)} villages")
        return success_count

def main():
    """
    Пример использования
    """
    fetcher = VillageFetcher()
    
    # Получаем конкретные деревни
    if len(sys.argv) > 1:
        # Из аргументов командной строки
        village_ids = [int(vid) for vid in sys.argv[1:]]
        print(f"🎯 Fetching specific villages: {village_ids}")
        villages = fetcher.fetch_specific_villages(village_ids)
    else:
        # Все деревни
        print("📦 Fetching all villages from game server...")
        villages = fetcher.fetch_all_villages()
    
    if villages:
        print(f"\n✅ Successfully fetched {len(villages)} villages:")
        for v in villages[:5]:  # Показываем первые 5
            print(f"  - {v['name']} (ID: {v['id']}) at ({v['x']}, {v['y']})")
        
        if len(villages) > 5:
            print(f"  ... and {len(villages) - 5} more")
        
        # Отправляем в прокси
        fetcher.send_to_proxy(villages)
    else:
        print("\n❌ Failed to fetch villages")
        sys.exit(1)

if __name__ == '__main__':
    main()
