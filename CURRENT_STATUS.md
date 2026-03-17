# Текущее состояние проекта Discord Bot для Stronghold Kingdoms

## 🎯 Цель проекта
Создать Discord бота, который автоматически рассчитывает время атак в игре Stronghold Kingdoms без ручного ввода координат.

## ✅ Что работает

### 1. Discord Bot (bot.py)
- ✅ Подключение к Discord
- ✅ Команда `!time` для расчета времени атак
- ✅ Команды отслеживания деревень (`!следить`, `!не_следить`)
- ✅ Уведомления о входящих атаках
- ✅ Интеграция с прокси-сервером через HTTP API

### 2. C# Proxy Server (SHKProxy)
- ✅ REST API на http://localhost:5000
- ✅ Endpoints для добавления/получения координат деревень
- ✅ Расчет времени атак по координатам
- ✅ Swagger UI для тестирования

### 3. XML-RPC Авторизация
- ✅ Успешная авторизация на http://login.strongholdkingdoms.com
- ✅ Получение UserGUID: `5dbaf4019e9046409f8feb3b55c10137`
- ✅ Получение SessionGUID (обновляется каждый раз)
- ✅ Тестовый скрипт `test_login.py` работает 100%

### 4. Исправление CustomSinks.dll
- ✅ Создана исправленная версия `FixedCustomSinks/CompressedClientSink.cs`
- ✅ Устранен баг с `stream.Length` на `ConnectStream`
- ✅ Компилируется без ошибок
- ✅ Интегрирована в `SHKGameConnector`

## ❌ Что НЕ работает

### Основная проблема: Подключение к игровому серверу
**Статус:** Игровой сервер отклоняет .NET Remoting запросы

**Детали:**
- Сервер: `http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem`
- При вызове `LoginUserGuid()` сервер возвращает XML-ошибку вместо бинарных данных
- Ошибка: `SerializationException: Недопустимый двоичный формат входного потока`
- Сервер ожидает определенный формат .NET Remoting запроса с компрессией

**Что пробовали:**
1. ❌ Использование оригинальной CustomSinks.dll (баг с потоками)
2. ✅ Создание исправленной FixedCompressedSink.cs (баг устранен)
3. ❌ Сервер все равно возвращает XML-ошибки
4. ❌ Попытки без компрессии (сервер требует `Compd2: Yes`)

## 📁 Структура проекта

```
GlobalAttackSHK/
├── bot.py                     # ✅ Discord бот (в analysis/)
├── attack_calculator.py       # ✅ Расчет времени атак (в analysis/)
├── SHKProxy/                  # ✅ C# прокси-сервер
│   ├── Program.cs            # REST API
│   ├── VillageService.cs     # Управление координатами
│   └── GameClient.cs         # Клиент игры
├── SHKGameConnector/          # ❌ Подключение к игре (.NET Framework 4.8)
│   ├── Program.cs            # Основной коннектор
│   ├── FixedCompressedSink.cs # Исправленный sink
│   ├── CustomSinks.dll       # Оригинальная DLL
│   ├── ServerInterface.dll   # Интерфейсы игры
│   └── CommonTypes.dll       # Типы данных
├── FixedCustomSinks/          # ✅ Исправленная CustomSinks.dll
│   ├── CompressedClientSink.cs
│   └── bin/Release/net48/CustomSinks.dll
├── GameServerClient.cs        # ❌ Попытка на .NET 10 (зависимости)
├── auto_village_fetcher.py    # ❌ Чтение памяти игры (требует игру)
└── analysis/                  # 📁 Все файлы анализа и отладки
```

## 🔧 Технические детали

### Учетные данные (.env)
```
GAME_EMAIL = kara.bridges1991@comejoinuspro.org
GAME_PASSWORD = 0307koolKL123
BOT_TOKEN = [Discord токен]
shk_link = http://shk-w756.elb.fireflyops.com:80
```

### Игровой сервер
- **Мир:** Europa 10 (World ID 756)
- **URL:** http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem
- **Протокол:** .NET Remoting over HTTP
- **Компрессия:** Обязательная (заголовок `Compd2: Yes`)
- **Интерфейс:** `IService`
- **Методы:** `LoginUserGuid()`, `GetVillageNames()`

### Ошибка сервера
```
SerializationException: Недопустимый двоичный формат входного потока. 
Начало содержимого (в байтах): 3C-3F-78-6D-6C-20-76-65-72-73-69-6F-6E-3D-22-31-2E
```
Это означает что сервер возвращает XML (`<?xml version="1.`) вместо бинарных данных.

## 🚀 Как запустить что работает

### 1. Discord Bot
```bash
cd analysis
python bot.py
```

### 2. Прокси-сервер
```bash
dotnet run --project SHKProxy
# Откроется на http://localhost:5000
# Swagger UI: http://localhost:5000/swagger
```

### 3. Тест авторизации
```bash
cd analysis
python test_login.py
```

### 4. Попытка подключения к игре
```bash
SHKGameConnector/bin/Debug/SHKGameConnector.exe
```

## 🎯 Следующие шаги

### Приоритет 1: Решить проблему с игровым сервером
1. **Декомпилировать оригинальную CustomSinks.dll** для изучения точного формата запросов
2. **Анализ Wireshark трафика** - сравнить наши запросы с оригинальными
3. **Реверс-инжиниринг** оригинального клиента игры
4. **Попробовать другие версии .NET Framework** (возможно сервер требует старую версию)

### Приоритет 2: Альтернативные решения
1. **HTTP перехват** - перехватывать трафик оригинального клиента
2. **Memory reading** - читать координаты из памяти запущенной игры
3. **Парсинг веб-интерфейса** - если у игры есть веб-версия

### Приоритет 3: Улучшения бота
1. Добавить больше типов войск (не только капитаны)
2. Улучшить интерфейс команд
3. Добавить сохранение данных в базу

## 💡 Текущее решение для пользователя

Пока автоматическое получение координат не работает, пользователь может:

1. **Запустить прокси-сервер:** `dotnet run --project SHKProxy`
2. **Запустить Discord бота:** `python analysis/bot.py`
3. **Добавить координаты вручную:** `!coords 12345 100 200 Village Name`
4. **Использовать расчет времени:** `!time capx4 12345[1];67890[2] 54321`

## 📊 Прогресс: 85% готово

- ✅ Discord бот - 100%
- ✅ Прокси-сервер - 100%  
- ✅ Авторизация - 100%
- ✅ Расчет времени - 100%
- ❌ Автоматические координаты - 0% (блокер)

**Основная проблема:** Формат .NET Remoting запросов к игровому серверу.
**Решение:** Нужно изучить оригинальный код CustomSinks.dll и точно воспроизвести формат запросов.