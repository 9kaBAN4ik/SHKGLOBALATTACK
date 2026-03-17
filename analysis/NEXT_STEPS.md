# Следующие шаги

## ✅ Выполнено

1. **Discord бот создан и работает**
   - Команда `!time` для расчета времени атак
   - Команда `!coords` для добавления координат
   - Команда `!addvillages` для тестовых данных

2. **C# Proxy Server работает**
   - Запущен на http://localhost:5000
   - API для добавления/получения координат
   - API для расчета времени атак

3. **Авторизация через XML-RPC работает!**
   - ✅ Успешно подключаемся к `http://login.strongholdkingdoms.com/services/auth.php`
   - ✅ Получаем UserGUID и SessionGUID
   - Метод: `login` (lowercase)
   - Параметры: `username`, `emailaddress`, `password` (lowercase)

## 🔄 В процессе

### Подключение к игровому серверу через .NET Remoting

**Проблема:** .NET Remoting не поддерживается в .NET Core/.NET 10

**Решение:** Создан отдельный проект на .NET Framework 4.8 (`SHKGameConnector`)

**Текущий статус:**
- Проект создан
- DLL скопированы (CommonTypes.dll, ServerInterface.dll, CustomSinks.dll)
- Интерфейс: `IService` (не `IGameServer`)
- Методы:
  - `LoginUserGuid(string username, string userGuid, string sessionGuid, bool needVillageData, int versionID)`
  - `GetVillageNames(int userID, int sessionID, long changePos)`

**Проблемы компиляции:**
- Не знаем точные имена полей в `LoginUserGuid_ReturnType` и `GetVillageNames_ReturnType`
- Нужно либо декомпилировать DLL, либо попробовать запустить и посмотреть на ошибки

## 📋 План действий

### Вариант 1: Декомпилировать DLL
1. Использовать ILSpy или dnSpy для просмотра CommonTypes.dll
2. Найти определения `LoginUserGuid_ReturnType` и `GetVillageNames_ReturnType`
3. Обновить код с правильными именами полей
4. Скомпилировать и запустить

### Вариант 2: Использовать dynamic
1. Изменить код, чтобы использовать `dynamic` вместо конкретных типов
2. Обращаться к полям через reflection
3. Скомпилировать и запустить
4. Посмотреть на ошибки во время выполнения

### Вариант 3: Ручное добавление координат (временное решение)
1. Пользователи добавляют координаты через `!coords <id> <x> <y> [name]`
2. Координаты сохраняются в прокси-сервере
3. Бот использует сохраненные координаты

## 🎯 Следующий шаг

**Рекомендуется:** Вариант 2 (dynamic)

Изменить `SHKGameConnector/Program.cs`:
```csharp
dynamic loginResult = gameServer.LoginUserGuid(...);
Console.WriteLine($"UserID: {loginResult.UserID}"); // или userID
```

Это позволит нам увидеть, какие поля доступны во время выполнения.

## 📝 Учетные данные

- Email: kara.bridges1991@comejoinuspro.org
- Password: 0307koolKL123
- UserGUID: 5dbaf4019e9046409f8feb3b55c10137
- SessionGUID: (генерируется при каждом входе)
- World: Europa 10 (ID: 756)
- Server: http://shk-w756.elb.fireflyops.com:80/KingdomsRPC/Kingdoms.rem

## 🔧 Файлы проекта

- `bot.py` - Discord бот
- `attack_calculator.py` - Расчет расстояний и времени
- `SHKProxy/` - C# прокси-сервер (.NET 10)
- `SHKGameConnector/` - Подключение к игре (.NET Framework 4.8)
- `test_login.py` - Тест XML-RPC авторизации (работает!)
- `get_worlds.py` - Получение списка миров (в разработке)

## 💡 Альтернативные подходы

1. **Перехват трафика**
   - Использовать Wireshark/Fiddler
   - Запустить игру и посмотреть на пакеты
   - Извлечь координаты из трафика

2. **Парсинг памяти игры**
   - Найти координаты в памяти процесса
   - Извлечь их программно

3. **Использовать API профильного сервера**
   - Возможно, есть другие методы XML-RPC для получения данных
   - Попробовать `GetWorlds`, `GetUserInfo` и т.д.
