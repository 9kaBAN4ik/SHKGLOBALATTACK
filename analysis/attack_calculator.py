"""
Калькулятор времени атак для Stronghold Kingdoms
"""
import math
from datetime import datetime, timedelta

class AttackCalculator:
    # Скорости войск (клеток в час)
    TROOP_SPEEDS = {
        'peasant': 10,
        'archer': 10,
        'pikeman': 10,
        'swordsman': 10,
        'catapult': 5,
        'scout': 20,
        'captain': 15  # Капитаны быстрее
    }
    
    def __init__(self):
        self.village_cache = {}  # Кэш координат деревень
    
    def calculate_distance(self, x1, y1, x2, y2):
        """Рассчитать расстояние между двумя точками"""
        return math.sqrt((x2 - x1)**2 + (y2 - y1)**2)
    
    def calculate_travel_time(self, distance, troop_type='captain', speed_multiplier=1.0):
        """
        Рассчитать время в пути
        distance - расстояние в клетках
        troop_type - тип войск
        speed_multiplier - множитель скорости (например, для карточек)
        """
        base_speed = self.TROOP_SPEEDS.get(troop_type, 10)
        actual_speed = base_speed * speed_multiplier
        
        # Время в часах
        hours = distance / actual_speed
        
        return timedelta(hours=hours)
    
    def format_time(self, td):
        """Форматировать timedelta в читаемый вид"""
        total_seconds = int(td.total_seconds())
        hours = total_seconds // 3600
        minutes = (total_seconds % 3600) // 60
        seconds = total_seconds % 60
        
        return f"{hours}h:{minutes}m:{seconds}s"
    
    def parse_attack_command(self, command_text):
        """
        Парсить команду типа: capx4 6515[1];74000[2];71593[3] 90618
        Возвращает: (attack_type, attacking_villages, target_village)
        """
        parts = command_text.strip().split()
        
        if len(parts) < 3:
            return None, None, None
        
        attack_type = parts[0]  # capx4, scout, etc
        attacking_str = parts[1]  # 6515[1];74000[2];...
        target_village = int(parts[2])  # 90618
        
        # Парсим атакующие деревни
        attacking_villages = []
        for village_str in attacking_str.split(';'):
            # Формат: 6515[1] или просто 6515
            if '[' in village_str:
                village_id = int(village_str.split('[')[0])
                count = int(village_str.split('[')[1].rstrip(']'))
            else:
                village_id = int(village_str)
                count = 1
            
            attacking_villages.append({
                'village_id': village_id,
                'count': count
            })
        
        return attack_type, attacking_villages, target_village

if __name__ == "__main__":
    calc = AttackCalculator()
    
    # Тест парсинга
    attack_type, attacking, target = calc.parse_attack_command(
        "capx4 6515[1];74000[2];71593[3];93485[5];45594[4] 90618"
    )
    
    print(f"Attack type: {attack_type}")
    print(f"Target: {target}")
    print(f"Attacking villages: {attacking}")
    
    # Тест расчета времени
    distance = 50  # клеток
    travel_time = calc.calculate_travel_time(distance, 'captain')
    print(f"\nDistance: {distance} tiles")
    print(f"Travel time: {calc.format_time(travel_time)}")
