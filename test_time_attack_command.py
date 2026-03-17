#!/usr/bin/env python
"""
Тестовый скрипт для проверки команды /time attack Discord бота
"""
import requests
import json

BASE_URL = "http://localhost:5000"

def test_add_villages():
    """Добавить тестовые деревни в кэш прокси"""
    print("=" * 60)
    print("ТЕСТ 1: Добавление тестовых деревень")
    print("=" * 60)
    
    villages = [
        {"id": 16107, "x": 100, "y": 200, "name": "Attack Village 1"},
        {"id": 74469, "x": 150, "y": 250, "name": "Attack Village 2"},
        {"id": 83239, "x": 200, "y": 300, "name": "Target Village"},
    ]
    
    for village in villages:
        response = requests.post(
            f"{BASE_URL}/api/village",
            json=village
        )
        
        if response.status_code == 200:
            print(f"✅ Деревня {village['id']} добавлена: ({village['x']}, {village['y']})")
        else:
            print(f"❌ Ошибка при добавлении деревни {village['id']}: {response.status_code}")
    
    print()

def test_calculate_attacks():
    """Протестировать расчет времени атак"""
    print("=" * 60)
    print("ТЕСТ 2: Расчет времени атак")
    print("=" * 60)
    
    data = {
        "targetVillageId": 83239,
        "attackingVillageIds": [16107, 74469]
    }
    
    response = requests.post(
        f"{BASE_URL}/api/calculate-attacks",
        json=data
    )
    
    if response.status_code == 200:
        result = response.json()
        print(f"✅ Расчет успешен!")
        print(f"\nЦелевая деревня: {result['target_village_name']} (ID: {result['target_village_id']})")
        print(f"\nАтакующие деревни:")
        
        for attack in result['attacks']:
            print(f"  - Village {attack['village_id']}: {attack['village_name']}")
            print(f"    Расстояние: {attack['distance']} tiles")
            print(f"    Время (x1): {attack['travel_time']}")
            print(f"    От: {attack['from_coords']} -> К: {attack['to_coords']}")
    else:
        print(f"❌ Ошибка: {response.status_code}")
        print(response.text)
    
    print()

def test_calculate_multipliers():
    """Рассчитать время для всех множителей скорости"""
    print("=" * 60)
    print("ТЕСТ 3: Расчет с множителями скорости x1-x6")
    print("=" * 60)
    
    # Получаем базовые данные
    data = {
        "targetVillageId": 83239,
        "attackingVillageIds": [16107, 74469]
    }
    
    response = requests.post(
        f"{BASE_URL}/api/calculate-attacks",
        json=data
    )
    
    if response.status_code != 200:
        print(f"❌ Ошибка получения данных: {response.status_code}")
        return
    
    result = response.json()
    
    # Выводим таблицу как в Discord боте
    print("\nТаблица времени атак:")
    print("+------------+-----------+-----------+-----------+-----------+-----------+-----------+")
    print("| Village_id | Attack x1 | Attack x2 | Attack x3 | Attack x4 | Attack x5 | Attack x6 |")
    print("+------------+-----------+-----------+-----------+-----------+-----------+-----------+")
    
    for attack in result['attacks']:
        if 'error' not in attack:
            village_id = attack['village_id']
            distance = attack['distance']
            
            # Рассчитываем время для каждого множителя
            times = []
            for mult in [1, 2, 3, 4, 5, 6]:
                speed = 15 * mult  # Скорость капитана = 15 tiles/hour
                hours = distance / speed
                
                h = int(hours)
                m = int((hours - h) * 60)
                s = int(((hours - h) * 60 - m) * 60)
                
                if h > 0:
                    time_str = f"{h}h:{m}m:{s}s"
                else:
                    time_str = f"{m}m:{s}s"
                
                times.append(time_str)
            
            # Форматируем строку таблицы
            print(f"|   {village_id:<8} | {times[0]:>9} | {times[1]:>9} | {times[2]:>9} | {times[3]:>9} | {times[4]:>9} | {times[5]:>9} |")
    
    print("+------------+-----------+-----------+-----------+-----------+-----------+-----------+")
    print("\n✅ Расчет множителей завершен")
    print()

def test_discord_command_format():
    """Показать пример использования команды Discord"""
    print("=" * 60)
    print("ПРИМЕР КОМАНДЫ DISCORD")
    print("=" * 60)
    print("\nДля использования в Discord введите:")
    print("\n  /time attack fromids: 16107;74469 targetid: 83239")
    print("\nБот вернет таблицу с расчетом времени для всех множителей скорости.")
    print()

def main():
    """Основная функция"""
    print("\n" + "=" * 60)
    print("🎮 ТЕСТИРОВАНИЕ КОМАНДЫ /time attack")
    print("=" * 60)
    print()
    
    try:
        # Проверяем доступность прокси
        response = requests.get(f"{BASE_URL}/api/status", timeout=2)
        if response.status_code != 200:
            print("❌ Прокси-сервер недоступен!")
            print("Запустите: python proxy_server.py")
            return
    except requests.exceptions.ConnectionError:
        print("❌ Не удалось подключиться к прокси-серверу!")
        print("Убедитесь, что прокси запущен: python proxy_server.py")
        return
    
    # Запускаем тесты
    test_add_villages()
    test_calculate_attacks()
    test_calculate_multipliers()
    test_discord_command_format()
    
    print("=" * 60)
    print("✅ ВСЕ ТЕСТЫ ЗАВЕРШЕНЫ")
    print("=" * 60)
    print("\nТеперь вы можете:")
    print("1. Запустить Discord бота: cd analysis && python bot.py")
    print("2. Использовать команду: /time attack fromids: 16107;74469 targetid: 83239")
    print()

if __name__ == "__main__":
    main()
