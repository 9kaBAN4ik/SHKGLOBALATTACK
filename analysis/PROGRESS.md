# Прогресс разработки Discord бота для Stronghold Kingdoms

## ✅ Выполнено

### 1. Discord бот
- Создан Discord бот с токеном
- Настроены права (MESSAGE CONTENT INTENT)
- Бот успешно подключается к Discord серверу
- Реализованы команды:
  - `!time <type> <attacking_villages> <target>` - расчет времени атак
  - `!coords <village_id> <x> <y> [name]` - добавление координат деревни
  - `!addvillages` - добавление тестовых деревень

### 2. C# Proxy Server
- Создан ASP.NET Core Web API на .NET 10.0
- Работает на http://localhost:5000
- Endpoints:
  - `POST /api/village` - добавить деревню
  - `GET /api/village/{id}` - получить деревню
  - `POST /api/calculate-attacks` - рассчитать время атак
- Использует in-memory кэш для хранения координат
- Рассчитывает расстояние по формуле Пифагора
- Рассчитывает время атаки с учетом типа (capx4, capx3, capx2, cap)

### 3. Авторизация в игре
- ✅ Успешно реализована авторизация через XML-RPC
- ✅ Получены UserGUID и SessionGUID
- Endpoint: `http://login.strongholdkingdoms.com/services/auth.php`
- Метод: `login`
- Параметры: `username`, `emailaddress`, `password` (lowercase)

### 4. Тестовые скрипты
- `test_login.py` - тест авторизации (работает!)
- `get_worlds.py` - получение списка миров (в разработке)

## 🔄 В процессе

### Подключение к игровому серверу
- Игровой сервер Europa 10: `http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem`
- Использует .NET Remoting протокол
- Проблема: .NET Remoting не поддерживается в .NET Core/.NET 10
- Решение: Нужно использовать .NET Framework 4.8 или найти альтернативный способ

## ❌ Проблемы

1. **. NET Remoting в .NET 10**
   - .NET Remoting - устаревшая технология, не поддерживается в .NET Core
   - Нужно либо использовать .NET Framework 4.8, либо найти другой способ подключения

2. **Получение координат деревень**
   - Метод `GetVillageNames` требует подключения через .NET Remoting
   - Альтернатива: ручное добавление координат через команду `!coords`

## 📋 Следующие шаги

### Вариант 1: Использовать .NET Framework 4.8
1. Пересоздать прокси-сервер на .NET Framework 4.8
2. Подключиться к игровому серверу через .NET Remoting
3. Вызвать `LoginUserGuid` с полученными GUID
4. Вызвать `GetVillageNames` для получения всех координат
5. Кэшировать координаты в памяти

### Вариант 2: Ручное добавление координат
1. Пользователи добавляют координаты через команду `!coords`
2. Координаты сохраняются в прокси-сервере
3. Бот использует сохраненные координаты для расчетов

### Вариант 3: Парсинг игрового трафика
1. Использовать `capture_traffic.py` для перехвата трафика
2. Извлекать координаты из пакетов
3. Автоматически добавлять в кэш

## 🎯 Текущая цель

Реализовать подключение к игровому серверу для автоматического получения координат деревень.

## 📝 Учетные данные

- Email: kara.bridges1991@comejoinuspro.org
- Password: 0307koolKL123
- UserGUID: 5dbaf4019e9046409f8feb3b55c10137
- SessionGUID: (генерируется при каждом входе)
- World: Europa 10 (ID: 756)
- Server: http://shk-w756.elb.fireflyops.com:80

## 🔧 Технологии

- Python 3.14
- discord.py 2.7.1
- ASP.NET Core 10.0 (Web API)
- C# 12
- .NET Remoting (для подключения к игре)
- XML-RPC (для авторизации)
