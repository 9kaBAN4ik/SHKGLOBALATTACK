# 🎯 РЕШЕНИЕ НАЙДЕНО!

## Как работает Discord бот на Linux сервере?

### Проблема:
- Бот на Linux → невозможно запустить игру
- Игроки видят только **villageID**, НЕ координаты
- .NET Remoting работает только из игры, не извне
- Нужен способ получить координаты автоматически

### Решение:

```
Windows PC              →    Linux Server
─────────────────────────────────────────────────
                            
1. Запустить игру         
                            
2. export_villages.ps1    
   ↓
   Подключение к серверу
   через .NET Remoting
   ↓
   villages.json           →  3. Загрузить файл
   (все координаты)            на сервер
                               
                               4. !loadvillages
                               в Discord
                               
                               5. !time all
                               работает! ✅
```

---

## Быстрый старт

### На Windows (один раз):

```powershell
# 1. Создайте .env
GAME_EMAIL=your@email.com
GAME_PASSWORD=yourpass
shk_link=http://shk-w756.elb.fireflyops.com:80

# 2. Запустите экспорт
.\export_villages.ps1

# 3. Получите villages.json с координатами всех деревень
```

### На Linux сервере:

```bash
# 1. Скопируйте villages.json на сервер
scp villages.json user@server:/bot/

# 2. Запустите Discord бота
cd /bot
python3 analysis/bot.py

# 3. В Discord выполните команду
!loadvillages
```

### Использование:

```
!time all fromids: 16107;74469 targetid: 83239
```

Бот вернет таблицу времени атак для всех множителей скорости! 🎉

---

## Структура проекта

```
.
├── analysis/
│   └── bot.py                    # Discord бот (Python)
├── VillageExporter.cs             # Экспорт координат (C#)
├── VillageExporter.csproj         # Проект для компиляции
├── export_villages.ps1            # PowerShell скрипт (запуск экспорта)
├── proxy_server.py                # Прокси сервер (опционально)
├── villages.json                  # СЮДА экспортируются координаты
├── villages_example.json          # Пример формата
└── EXPORT_VILLAGES_GUIDE.md       # Детальная инструкция
```

---

## Как это работает?

### 1. VillageExporter (Windows)

**C# программа** которая:
- ✅ Авторизуется через XML-RPC
- ✅ Подключается к игровому серверу через .NET Remoting
- ✅ Вызывает `LoginUserGuid()` для получения данных
- ✅ Извлекает координаты всех деревень
- ✅ Сохраняет в `villages.json`

**Почему работает?**
- Использует **оригинальные DLL игры** (ServerInterface.dll, CustomSinks.dll)
- .NET Remoting с компрессией работает только из игрового клиента
- Мы эмулируем игровой клиент на уровне протокола

### 2. Discord Bot (Linux)

**Python бот** который:
- ✅ Загружает `villages.json` через команду `!loadvillages`
- ✅ Сохраняет координаты в памяти и прокси-сервере
- ✅ Рассчитывает расстояние между деревнями (формула Пифагора)
- ✅ Возвращает время атак для 6 множителей скорости

**Команды:**
- `!loadvillages` - загрузить координаты из JSON
- `!time all fromids: X;Y targetid: Z` - рассчитать время атак
- `!coords ID X Y Name` - добавить одну деревню вручную

---

## Преимущества решения

✅ **Работает на Linux** - бот не требует Windows  
✅ **Без игры** - не нужно держать игру запущенной  
✅ **Один раз** - экспорт координат делается раз, при захвате новой деревни  
✅ **Безопасно** - не модифицирует игру, использует официальный протокол  
✅ **Быстро** - экспорт занимает 5-10 секунд  

---

## Альтернативы

### Если .NET Remoting не работает:

1. **Memory Reader** - читать из памяти запущенной игры
2. **Ручной ввод** - команда `!coords` для каждой деревни
3. **Web scraping** - если есть веб-интерфейс игры

---

## Обновление координат

При захвате новой деревни:

```powershell
# На Windows
.\export_villages.ps1
```

```bash
# Скопировать на сервер
scp villages.json user@server:/bot/
```

```
# В Discord
!loadvillages
```

Готово! Новые деревни добавлены ✅

---

## Технические детали

### Скорость капитана:
- Базовая: **15 tiles/hour**
- x2: **30 tiles/hour**
- x3: **45 tiles/hour**
- x4: **60 tiles/hour**
- x5: **75 tiles/hour**
- x6: **90 tiles/hour**

### Формула расчета:
```python
distance = sqrt((x2 - x1)^2 + (y2 - y1)^2)
time_hours = distance / speed
```

### Формат villages.json:
```json
[
  {
    "id": 16107,
    "x": 423,
    "y": 582,
    "name": "Castle"
  }
]
```

---

## Поддержка

📖 **Полная инструкция:** [EXPORT_VILLAGES_GUIDE.md](EXPORT_VILLAGES_GUIDE.md)  
🔧 **Техническая документация:** [AUTO_FETCH_COORDINATES.md](AUTO_FETCH_COORDINATES.md)  

**Проблемы?**
1. Проверьте `.env` файл
2. Убедитесь что игровой сервер доступен
3. Проверьте формат `villages.json`
4. Используйте `villages_example.json` для тестов

---

## Что дальше?

1. ✅ Экспортируйте координаты на Windows
2. ✅ Загрузите на Linux сервер
3. ✅ Запустите бота
4. ✅ Используйте `!time all` для расчета атак
5. ✅ Наслаждайтесь! 🎉

**Бот готов к работе на вашем Linux сервере!** 🚀
