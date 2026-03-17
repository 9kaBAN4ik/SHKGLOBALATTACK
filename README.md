# 🎮 SHKGLOBALATTACK - Stronghold Kingdoms Discord Bot

Автоматический Discord бот для расчета времени атак в игре Stronghold Kingdoms.

## 📊 Статус проекта

✅ **Что работает** (85% готово):
- REST API прокси-сервер (Python Flask)
- Discord бот с командами управления атаками
- Калькулятор времени атак
- Тест авторизации в игре (XML-RPC)

❌ **Что не работает**:
- Автоматическое получение координат из игры (.NET Remoting)
- Координаты нужно добавлять вручную

## 🚀 Быстрый старт

### 1. Запустить прокси-сервер

Прокси-сервер уже запущен и доступен по адресу:
- **REST API**: http://localhost:5000
- **Status**: http://localhost:5000/api/status

### 2. Запустить Discord бота (в отдельном терминале)

```bash
cd analysis
python bot.py
```

### 3. Использовать в Discord

Доступные команды:
```
!ping                                    # Проверить работу бота
!следить 12345 Моя деревня               # Начать отслеживать деревню
!не_следить 12345                        # Прекратить отслеживание
!список_деревень                         # Показать отслеживаемые деревни
!coords 12345 100 200 Village Name       # Добавить координаты деревни
/time attack fromids: 16107;74469 targetid: 83239  # Рассчитать атаки с множителями x1-x6
```

#### Новая команда: `/time attack`

Рассчитывает время атак с множителями скорости x1, x2, x3, x4, x5, x6.

**Формат:**
```
/time attack fromids: <id1;id2;...> targetid: <target_id>
```

**Пример:**
```
/time attack fromids: 16107;74469 targetid: 83239
```

**Результат:**
```
+------------+-----------+-----------+-----------+-----------+-----------+-----------+
| Village_id | Attack x1 | Attack x2 | Attack x3 | Attack x4 | Attack x5 | Attack x6 |
+------------+-----------+-----------+-----------+-----------+-----------+-----------+
|   16107    |   6m:5s   |   3m:2s   |   2m:2s   |   1m:31s  |   1m:13s  |    1m:1   |
|   74469    |   6m:16s  |   3m:8s   |   2m:5s   |   1m:34s  |   1m:15s  |   1m:3s   |
+------------+-----------+-----------+-----------+-----------+-----------+-----------+
```

## 📖 API Документация

### Добавить координаты деревни

```bash
curl -X POST http://localhost:5000/api/village \
  -H 'Content-Type: application/json' \
  -d '{
    "id": 12345,
    "x": 100,
    "y": 200,
    "name": "My Village"
  }'
```

### Получить координаты деревни

```bash
curl http://localhost:5000/api/village/12345
```

### Получить все деревни

```bash
curl http://localhost:5000/api/villages
```

### Рассчитать время атак

```bash
curl -X POST http://localhost:5000/api/calculate-attacks \
  -H 'Content-Type: application/json' \
  -d '{
    "targetVillageId": 54321,
    "attackingVillageIds": [12345, 67890]
  }'
```

## 🧪 Тестирование

### Тест авторизации в игре

```bash
cd analysis
python test_login.py
```

Этот тест проверяет авторизацию на сервере `login.strongholdkingdoms.com`.

## 📁 Структура проекта

```
SHKGLOBALATTACK/
├── proxy_server.py          # ✅ Python REST API прокси-сервер
├── main.py                  # Главный запускаемый файл с инструкциями
├── analysis/
│   ├── bot.py              # ✅ Discord бот
│   ├── attack_calculator.py # ✅ Калькулятор времени атак
│   └── test_login.py       # ✅ Тест авторизации
├── .env                    # Конфигурация (токены, пароли)
└── CURRENT_STATUS.md       # Детальный статус проекта
```

## 🔧 Конфигурация

Файл `.env` содержит:
```env
shk_link=http://shk-w756.elb.fireflyops.com:80
BOT_TOKEN=your_discord_bot_token_here
GAME_EMAIL=your_game_email@example.com
GAME_PASSWORD=your_game_password
```

## 💡 Примеры использования

### 1. Добавить деревни через API

```bash
# Добавить атакующую деревню #1
curl -X POST http://localhost:5000/api/village \
  -H 'Content-Type: application/json' \
  -d '{"id": 12345, "x": 100, "y": 200, "name": "Attack Village 1"}'

# Добавить атакующую деревню #2
curl -X POST http://localhost:5000/api/village \
  -H 'Content-Type: application/json' \
  -d '{"id": 67890, "x": 150, "y": 250, "name": "Attack Village 2"}'

# Добавить целевую деревню
curl -X POST http://localhost:5000/api/village \
  -H 'Content-Type: application/json' \
  -d '{"id": 54321, "x": 200, "y": 300, "name": "Target Village"}'
```

### 2. Рассчитать время атак

```bash
curl -X POST http://localhost:5000/api/calculate-attacks \
  -H 'Content-Type: application/json' \
  -d '{
    "targetVillageId": 54321,
    "attackingVillageIds": [12345, 67890]
  }'
```

Ответ:
```json
{
  "target_village_id": 54321,
  "target_village_name": "Target Village",
  "attacks": [
    {
      "village_id": 12345,
      "village_name": "Attack Village 1",
      "distance": 141.42,
      "travel_time": "9h:25m:41s",
      "from_coords": "(100, 200)",
      "to_coords": "(200, 300)"
    },
    {
      "village_id": 67890,
      "village_name": "Attack Village 2",
      "distance": 70.71,
      "travel_time": "4h:42m:50s",
      "from_coords": "(150, 250)",
      "to_coords": "(200, 300)"
    }
  ]
}
```

### 3. Использовать в Discord

После добавления координат через API, используйте команду в Discord:

```
!time capx4 12345[1];67890[2] 54321
```

Бот запросит координаты у прокси-сервера и рассчитает время атак.

## 🎯 Следующие шаги

1. ✅ Прокси-сервер запущен
2. ✅ API работает
3. ⏳ Запустить Discord бота (в отдельном терминале)
4. ⏳ Добавить координаты деревень через API
5. ⏳ Использовать команды в Discord

## 🐛 Известные проблемы

- **Автоматическое получение координат не работает**: Из-за проблем с .NET Remoting протоколом игры. Координаты нужно добавлять вручную через API.
- **C# компоненты не работают**: Нет .NET SDK в окружении, используется Python замена.

## 📚 Дополнительная информация

Для детальной информации о проекте см. [CURRENT_STATUS.md](CURRENT_STATUS.md)

## 🔗 Полезные ссылки

- REST API: http://localhost:5000
- API Status: http://localhost:5000/api/status
- Game Server: http://shk-w756.elb.fireflyops.com:80
