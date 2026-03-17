# Тестирование команды `/time attack`

## Описание
Команда `/time attack` рассчитывает время атак с множителями скорости x1, x2, x3, x4, x5, x6.

## Формат команды
```
/time attack fromids: <id1;id2;...> targetid: <target_id>
```

## Пример использования

### Шаг 1: Добавить координаты деревень
Используйте команду `!coords` для добавления координат:
```
!coords 16107 100 200 Village 16107
!coords 74469 150 250 Village 74469  
!coords 83239 200 300 Target Village
```

### Шаг 2: Рассчитать время атак
```
/time attack fromids: 16107;74469 targetid: 83239
```

## Ожидаемый результат

Бот вернёт таблицу с расчётом времени для каждого множителя скорости:

```
+------------+-----------+-----------+-----------+-----------+-----------+-----------+
| Village_id | Attack x1 | Attack x2 | Attack x3 | Attack x4 | Attack x5 | Attack x6 |
+------------+-----------+-----------+-----------+-----------+-----------+-----------+
|   16107    |   9h:25m:41s   |   4h:42m:50s   |   3h:8m:33s   |   2h:21m:25s  |   1h:53m:8s  |   1h:34m:17s   |
|   74469    |   4h:42m:50s   |   2h:21m:25s   |   1h:34m:17s   |   1h:10m:42s  |   0h:56m:34s  |   0h:47m:5s   |
+------------+-----------+-----------+-----------+-----------+-----------+-----------+
```

## Множители скорости

- **x1** - базовая скорость (15 tiles/hour)
- **x2** - удвоенная скорость (30 tiles/hour)
- **x3** - утроенная скорость (45 tiles/hour)
- **x4** - учетверённая скорость (60 tiles/hour)
- **x5** - ускорение x5 (75 tiles/hour)
- **x6** - максимальное ускорение (90 tiles/hour)

## Проверка работы API

### Добавить тестовые деревни через API:
```bash
curl -X POST http://localhost:5000/api/village \
  -H 'Content-Type: application/json' \
  -d '{"id": 16107, "x": 100, "y": 200, "name": "Village 16107"}'

curl -X POST http://localhost:5000/api/village \
  -H 'Content-Type: application/json' \
  -d '{"id": 74469, "x": 150, "y": 250, "name": "Village 74469"}'

curl -X POST http://localhost:5000/api/village \
  -H 'Content-Type: application/json' \
  -d '{"id": 83239, "x": 200, "y": 300, "name": "Target Village"}'
```

### Проверить расчёт:
```bash
curl -X POST http://localhost:5000/api/calculate-attacks \
  -H 'Content-Type: application/json' \
  -d '{"targetVillageId": 83239, "attackingVillageIds": [16107, 74469]}'
```

Ожидаемый ответ:
```json
{
  "attacks": [
    {
      "distance": 141.42,
      "from_coords": "(100, 200)",
      "to_coords": "(200, 300)",
      "travel_time": "9h:25m:41s",
      "village_id": 16107,
      "village_name": "Village 16107"
    },
    {
      "distance": 70.71,
      "from_coords": "(150, 250)",
      "to_coords": "(200, 300)",
      "travel_time": "4h:42m:50s",
      "village_id": 74469,
      "village_name": "Village 74469"
    }
  ],
  "target_village_id": 83239,
  "target_village_name": "Target Village"
}
```

## Возможные ошибки

### Ошибка: "Деревни не найдены в кэше"
**Решение:** Добавьте координаты деревень командой `!coords <id> <x> <y> <название>`

### Ошибка: "Не удалось подключиться к прокси-серверу"
**Решение:** Убедитесь, что прокси запущен: `python proxy_server.py`

### Ошибка: "Неверный формат"
**Решение:** Проверьте синтаксис команды:
- Должны быть указаны оба параметра: `fromids:` и `targetid:`
- ID деревень разделяются точкой с запятой: `16107;74469`
- Пробелы после двоеточий обязательны

## Запуск системы

### 1. Запустить прокси-сервер:
```bash
python proxy_server.py
```

### 2. Запустить Discord бота (в отдельном терминале):
```bash
cd analysis
python bot.py
```

### 3. В Discord использовать команду:
```
/time attack fromids: 16107;74469 targetid: 83239
```
