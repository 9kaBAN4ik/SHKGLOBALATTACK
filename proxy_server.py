"""
Python REST API Proxy для Stronghold Kingdoms
Заменяет C# прокси-сервер, предоставляя API для Discord бота
"""
from flask import Flask, jsonify, request
import math
from typing import Dict, Optional
import subprocess
import json
import os
from dotenv import load_dotenv

# Загружаем переменные окружения
load_dotenv()

app = Flask(__name__)

# Кэш координат деревень {village_id: {id, x, y, name}}
villages_cache: Dict[int, dict] = {}

class VillageService:
    """Сервис для управления координатами деревень"""
    
    @staticmethod
    def cache_village(village_id: int, x: int, y: int, name: str):
        """Добавить деревню в кэш"""
        villages_cache[village_id] = {
            'id': village_id,
            'x': x,
            'y': y,
            'name': name
        }
    
    @staticmethod
    def get_village(village_id: int) -> Optional[dict]:
        """Получить координаты деревни"""
        return villages_cache.get(village_id)
    
    @staticmethod
    def get_all_villages() -> Dict[int, dict]:
        """Получить все деревни"""
        return villages_cache
    
    @staticmethod
    def calculate_distance(x1: int, y1: int, x2: int, y2: int) -> float:
        """Рассчитать расстояние между координатами"""
        dx = x2 - x1
        dy = y2 - y1
        return math.sqrt(dx * dx + dy * dy)
    
    @staticmethod
    def calculate_travel_time(distance: float, troop_speed: float = 15.0) -> str:
        """Рассчитать время в пути (капитаны = 15 клеток/час)"""
        hours = distance / troop_speed
        h = int(hours)
        m = int((hours - h) * 60)
        s = int(((hours - h) * 60 - m) * 60)
        return f"{h}h:{m}m:{s}s"

@app.route('/')
def index():
    """Главная страница"""
    return jsonify({
        'service': 'Stronghold Kingdoms Proxy API',
        'status': 'Ready',
        'cached_villages': len(villages_cache)
    })

@app.route('/api/village/<int:village_id>', methods=['GET'])
def get_village(village_id: int):
    """Получить координаты деревни"""
    village = VillageService.get_village(village_id)
    
    if village is None:
        return jsonify({'error': f'Village {village_id} not found'}), 404
    
    return jsonify(village)

@app.route('/api/village', methods=['POST'])
def add_village():
    """Добавить деревню в кэш"""
    data = request.json
    
    if not data or 'id' not in data or 'x' not in data or 'y' not in data:
        return jsonify({'error': 'Missing required fields: id, x, y'}), 400
    
    village_id = int(data['id'])
    x = int(data['x'])
    y = int(data['y'])
    name = data.get('name', f'Village_{village_id}')
    
    VillageService.cache_village(village_id, x, y, name)
    
    return jsonify({
        'message': 'Village cached',
        'village': {
            'id': village_id,
            'x': x,
            'y': y,
            'name': name
        }
    })

@app.route('/api/villages', methods=['GET'])
def get_all_villages():
    """Получить все деревни"""
    return jsonify({
        'count': len(villages_cache),
        'villages': list(villages_cache.values())
    })

@app.route('/api/calculate-attacks', methods=['POST'])
def calculate_attacks():
    """Рассчитать время атак"""
    data = request.json
    
    if not data or 'targetVillageId' not in data or 'attackingVillageIds' not in data:
        return jsonify({'error': 'Missing required fields'}), 400
    
    target_village_id = int(data['targetVillageId'])
    attacking_village_ids = data['attackingVillageIds']
    
    # Получаем целевую деревню
    target_village = VillageService.get_village(target_village_id)
    if target_village is None:
        return jsonify({'error': f'Target village {target_village_id} not found'}), 404
    
    results = []
    
    for attacking_id in attacking_village_ids:
        attacking_village = VillageService.get_village(attacking_id)
        
        if attacking_village is None:
            results.append({
                'village_id': attacking_id,
                'error': 'Not found'
            })
            continue
        
        # Рассчитать расстояние
        distance = VillageService.calculate_distance(
            attacking_village['x'],
            attacking_village['y'],
            target_village['x'],
            target_village['y']
        )
        
        # Рассчитать время в пути
        travel_time = VillageService.calculate_travel_time(distance)
        
        results.append({
            'village_id': attacking_id,
            'village_name': attacking_village['name'],
            'distance': round(distance, 2),
            'travel_time': travel_time,
            'from_coords': f"({attacking_village['x']}, {attacking_village['y']})",
            'to_coords': f"({target_village['x']}, {target_village['y']})"
        })
    
    return jsonify({
        'target_village_id': target_village_id,
        'target_village_name': target_village['name'],
        'attacks': results
    })

@app.route('/api/fetch-villages', methods=['POST'])
def fetch_villages_from_game():
    """Получить координаты деревень с сервера игры"""
    data = request.json
    
    # Получаем village IDs для загрузки
    village_ids = data.get('village_ids', [])
    
    if not village_ids:
        return jsonify({'error': 'No village IDs provided'}), 400
    
    try:
        # Вызываем GameServerClient для получения координат
        # Используем dotnet для запуска C# приложения
        env = os.environ.copy()
        
        result = subprocess.run(
            ['dotnet', 'run', '--project', 'GameServerClient.cs'],
            capture_output=True,
            text=True,
            timeout=30,
            env=env
        )
        
        if result.returncode != 0:
            return jsonify({
                'error': 'Failed to fetch villages from game server',
                'details': result.stderr
            }), 500
        
        # Парсим результат (предполагаем JSON output)
        try:
            villages_data = json.loads(result.stdout)
            
            # Добавляем деревни в кэш
            cached_count = 0
            for village in villages_data:
                if village['id'] in village_ids:
                    VillageService.cache_village(
                        village['id'],
                        village['x'],
                        village['y'],
                        village['name']
                    )
                    cached_count += 1
            
            return jsonify({
                'message': f'Fetched and cached {cached_count} villages',
                'cached_villages': cached_count
            })
        except json.JSONDecodeError:
            return jsonify({
                'error': 'Invalid response from game server',
                'output': result.stdout
            }), 500
            
    except subprocess.TimeoutExpired:
        return jsonify({'error': 'Request to game server timed out'}), 504
    except Exception as e:
        return jsonify({'error': f'Failed to fetch villages: {str(e)}'}), 500

@app.route('/api/auto-calculate-attacks', methods=['POST'])
def auto_calculate_attacks():
    """Автоматически получить координаты и рассчитать время атак"""
    data = request.json
    
    if not data or 'targetVillageId' not in data or 'attackingVillageIds' not in data:
        return jsonify({'error': 'Missing required fields'}), 400
    
    target_village_id = int(data['targetVillageId'])
    attacking_village_ids = [int(vid) for vid in data['attackingVillageIds']]
    
    # Проверяем какие деревни отсутствуют в кэше
    missing_villages = []
    
    if VillageService.get_village(target_village_id) is None:
        missing_villages.append(target_village_id)
    
    for vid in attacking_village_ids:
        if VillageService.get_village(vid) is None:
            missing_villages.append(vid)
    
    # Если есть недостающие деревни, пытаемся получить их с сервера
    if missing_villages:
        print(f"⚠️ Недостающие деревни: {missing_villages}")
        print("📡 Попытка получить данные с игрового сервера...")
        
        # В реальной системе здесь должен быть вызов к игровому серверу
        # Пока возвращаем ошибку с информацией о недостающих деревнях
        return jsonify({
            'error': 'Villages not found in cache',
            'missing_villages': missing_villages,
            'message': 'Please add village coordinates using !coords command or the game server integration'
        }), 404
    
    # Если все деревни в кэше, выполняем расчет
    return calculate_attacks()

@app.route('/api/status', methods=['GET'])
def status():
    """Статус сервиса"""
    return jsonify({
        'status': 'running',
        'cached_villages': len(villages_cache),
        'endpoints': [
            'GET /',
            'GET /api/village/<id>',
            'POST /api/village',
            'GET /api/villages',
            'POST /api/calculate-attacks',
            'POST /api/auto-calculate-attacks',
            'POST /api/fetch-villages',
            'GET /api/status'
        ]
    })

if __name__ == '__main__':
    print("=" * 60)
    print("🎮 SHKGLOBALATTACK - Python Proxy Server")
    print("=" * 60)
    print(f"🌐 REST API: http://localhost:5000")
    print(f"📊 Status: http://localhost:5000/api/status")
    print(f"📖 API Documentation:")
    print(f"   - GET  /api/village/<id>    - Get village coordinates")
    print(f"   - POST /api/village          - Add village to cache")
    print(f"   - GET  /api/villages         - Get all villages")
    print(f"   - POST /api/calculate-attacks - Calculate attack times")
    print("=" * 60)
    print("\n💡 Для использования с Discord ботом:")
    print("   1. Запустите этот прокси: python proxy_server.py")
    print("   2. Запустите Discord бота: python analysis/bot.py")
    print("\n")
    
    app.run(host='0.0.0.0', port=5000, debug=False)
