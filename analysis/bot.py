import discord
from discord.ext import commands, tasks
import os
from dotenv import load_dotenv
from datetime import datetime, timedelta
import asyncio
from attack_calculator import AttackCalculator

# Загружаем переменные из .env
load_dotenv()
TOKEN = os.getenv('BOT_TOKEN')
SHK_LINK = os.getenv('shk_link')

# Создаем бота с префиксом команд !
intents = discord.Intents.default()
intents.message_content = True
bot = commands.Bot(command_prefix='!', intents=intents)

# Хранилище отслеживаемых деревень {village_id: {channel_id, name}}
watched_villages = {}

# Хранилище атак {army_id: {data}}
attacks = {}

# Калькулятор атак
calculator = AttackCalculator()

# Временное хранилище координат деревень (пока нет подключения к серверу)
# TODO: Заменить на реальные данные с сервера
village_coords = {}

@bot.event
async def on_ready():
    print(f'Бот {bot.user} успешно запущен!')
    print(f'ID: {bot.user.id}')
    print(f'Сервер игры: {SHK_LINK}')
    check_attacks.start()

@bot.command(name='ping')
async def ping(ctx):
    """Проверка работы бота"""
    await ctx.send(f'🏓 Понг! Задержка: {round(bot.latency * 1000)}ms')

@bot.command(name='следить')
async def watch_village(ctx, village_id: int, *, название: str = None):
    """
    Начать отслеживать деревню
    Пример: !следить 12345 Моя деревня
    """
    watched_villages[village_id] = {
        'channel_id': ctx.channel.id,
        'name': название or f"Деревня #{village_id}"
    }
    
    embed = discord.Embed(
        title="👁️ Деревня добавлена в отслеживание",
        description=f"ID: {village_id}\nНазвание: {watched_villages[village_id]['name']}",
        color=discord.Color.green()
    )
    embed.add_field(name="Канал уведомлений", value=ctx.channel.mention, inline=False)
    
    await ctx.send(embed=embed)

@bot.command(name='не_следить')
async def unwatch_village(ctx, village_id: int):
    """Прекратить отслеживать деревню"""
    if village_id in watched_villages:
        name = watched_villages[village_id]['name']
        del watched_villages[village_id]
        await ctx.send(f"✅ Деревня {name} (ID: {village_id}) удалена из отслеживания")
    else:
        await ctx.send(f"❌ Деревня с ID {village_id} не отслеживается")

@bot.command(name='список_деревень')
async def list_villages(ctx):
    """Показать все отслеживаемые деревни"""
    if not watched_villages:
        await ctx.send("📋 Нет отслеживаемых деревень")
        return
    
    embed = discord.Embed(
        title="📋 Отслеживаемые деревни",
        color=discord.Color.blue()
    )
    
    for village_id, data in watched_villages.items():
        channel = bot.get_channel(data['channel_id'])
        embed.add_field(
            name=f"{data['name']}", 
            value=f"ID: {village_id}\nКанал: {channel.mention if channel else 'Неизвестно'}",
            inline=False
        )
    
    await ctx.send(embed=embed)

@bot.command(name='добавить_атаку')
async def add_attack(ctx, target_village_id: int, время_прибытия: str, *, описание: str = None):
    """
    Добавить атаку на деревню
    Пример: !добавить_атаку 12345 14:30 Атака от игрока X
    Или: !добавить_атаку 12345 2026-03-16_14:30 Атака от игрока X
    """
    try:
        # Парсим время
        if '_' in время_прибытия:
            arrival_time = datetime.strptime(время_прибытия, '%Y-%m-%d_%H:%M')
        else:
            today = datetime.now().date()
            time_obj = datetime.strptime(время_прибытия, '%H:%M').time()
            arrival_time = datetime.combine(today, time_obj)
            
            # Если время уже прошло сегодня, берем завтра
            if arrival_time < datetime.now():
                arrival_time += timedelta(days=1)
        
        # Генерируем ID
        attack_id = len(attacks) + 1
        
        # Определяем канал для уведомлений
        if target_village_id in watched_villages:
            channel_id = watched_villages[target_village_id]['channel_id']
            village_name = watched_villages[target_village_id]['name']
        else:
            channel_id = ctx.channel.id
            village_name = f"Деревня #{target_village_id}"
        
        # Сохраняем атаку
        attacks[attack_id] = {
            'target_village_id': target_village_id,
            'village_name': village_name,
            'arrival_time': arrival_time,
            'description': описание or "Входящая атака",
            'channel_id': channel_id,
            'notified_5min': False,
            'notified_1min': False
        }
        
        time_until = arrival_time - datetime.now()
        hours = int(time_until.total_seconds() // 3600)
        minutes = int((time_until.total_seconds() % 3600) // 60)
        
        embed = discord.Embed(
            title="⚔️ Атака добавлена",
            description=f"**Цель:** {village_name} (ID: {target_village_id})\n**Описание:** {attacks[attack_id]['description']}",
            color=discord.Color.red()
        )
        embed.add_field(name="Время прибытия", value=arrival_time.strftime('%Y-%m-%d %H:%M'), inline=False)
        embed.add_field(name="Осталось", value=f"{hours}ч {minutes}мин", inline=False)
        embed.add_field(name="ID атаки", value=f"#{attack_id}", inline=False)
        
        await ctx.send(embed=embed)
        
    except ValueError:
        await ctx.send("❌ Неверный формат! Используй: `!добавить_атаку <ID_деревни> <время> <описание>`\nПример: `!добавить_атаку 12345 14:30 Атака от игрока X`")

@bot.command(name='список_атак')
async def list_attacks(ctx, village_id: int = None):
    """
    Показать все активные атаки
    Пример: !список_атак - все атаки
    Или: !список_атак 12345 - атаки на конкретную деревню
    """
    if not attacks:
        await ctx.send("📋 Нет активных атак")
        return
    
    embed = discord.Embed(
        title="📋 Активные атаки",
        color=discord.Color.blue()
    )
    
    now = datetime.now()
    found = False
    
    for attack_id, data in attacks.items():
        # Фильтр по деревне, если указан ID
        if village_id and data['target_village_id'] != village_id:
            continue
            
        time_until = data['arrival_time'] - now
        if time_until.total_seconds() > 0:
            found = True
            hours = int(time_until.total_seconds() // 3600)
            minutes = int((time_until.total_seconds() % 3600) // 60)
            embed.add_field(
                name=f"#{attack_id}: {data['description']}", 
                value=f"🎯 Цель: {data['village_name']} (ID: {data['target_village_id']})\n⏰ {data['arrival_time'].strftime('%H:%M')} (через {hours}ч {minutes}мин)",
                inline=False
            )
    
    if not found:
        if village_id:
            await ctx.send(f"📋 Нет активных атак на деревню ID {village_id}")
        else:
            await ctx.send("📋 Нет активных атак")
    else:
        await ctx.send(embed=embed)

@bot.command(name='удалить_атаку')
async def remove_attack(ctx, attack_id: int):
    """Удалить атаку по ID"""
    if attack_id in attacks:
        del attacks[attack_id]
        await ctx.send(f"✅ Атака #{attack_id} удалена")
    else:
        await ctx.send(f"❌ Атака #{attack_id} не найдена")

@bot.command(name='time')
async def calculate_attack_time(ctx, *, command_text: str):
    """
    Рассчитать время атак
    Пример: !time capx4 6515[1];74000[2];71593[3];93485[5];45594[4] 90618
    """
    try:
        # Парсим команду
        attack_type, attacking_villages, target_village = calculator.parse_attack_command(command_text)
        
        if not attacking_villages:
            await ctx.send("❌ Неверный формат команды!\nПример: `!time capx4 6515[1];74000[2] 90618`")
            return
        
        # Получаем ID деревень
        attacking_ids = [v['village_id'] for v in attacking_villages]
        
        # Запрос к прокси-серверу
        try:
            import requests
            response = requests.post(
                'http://localhost:5000/api/calculate-attacks',
                json={
                    'targetVillageId': target_village,
                    'attackingVillageIds': attacking_ids
                },
                timeout=5
            )
            
            if response.status_code == 200:
                data = response.json()
                attacks_data = data['attacks']
            else:
                # Если прокси не работает, используем локальный расчет
                attacks_data = []
                for village in attacking_villages:
                    village_id = village['village_id']
                    if village_id in village_coords and target_village in village_coords:
                        v1 = village_coords[village_id]
                        v2 = village_coords[target_village]
                        distance = calculator.calculate_distance(v1['x'], v1['y'], v2['x'], v2['y'])
                        travel_time = calculator.calculate_travel_time(distance, 'captain')
                        attacks_data.append({
                            'village_id': village_id,
                            'distance': round(distance, 2),
                            'travel_time': calculator.format_time(travel_time)
                        })
                    else:
                        attacks_data.append({
                            'village_id': village_id,
                            'error': 'Coordinates not found'
                        })
        except Exception as e:
            await ctx.send(f"❌ Ошибка подключения к прокси-серверу: {e}\nИспользуй `!coords` для добавления координат")
            return
        
        # Создаем embed с результатами
        embed = discord.Embed(
            title=f"⚔️ Расчет времени атак",
            description=f"**Цель:** Деревня #{target_village}\n**Тип:** {attack_type}",
            color=discord.Color.blue()
        )
        
        # Таблица результатов
        table = "```\n"
        table += "+-------------+------------+\n"
        table += "| Village_id  | Time       |\n"
        table += "+-------------+------------+\n"
        
        for i, village in enumerate(attacking_villages):
            village_id = village['village_id']
            count = village['count']
            
            attack_data = attacks_data[i] if i < len(attacks_data) else {}
            
            if 'error' in attack_data:
                time_str = "NOT FOUND"
            else:
                time_str = attack_data.get('travel_time', 'ERROR')
            
            table += f"| {village_id:>6}[{count}]  | {time_str:>10} |\n"
        
        table += "+-------------+------------+\n"
        table += "```"
        
        embed.add_field(name="Время прибытия", value=table, inline=False)
        embed.set_footer(text="✅ Данные получены с прокси-сервера")
        
        await ctx.send(embed=embed)
        
    except Exception as e:
        await ctx.send(f"❌ Ошибка: {str(e)}")

@bot.command(name='coords')
async def set_village_coords(ctx, village_id: int, x: int, y: int, *, name: str = ""):
    """
    Установить координаты деревни
    Пример: !coords 6515 100 200 Village Name
    """
    # Добавляем локально
    village_coords[village_id] = {'x': x, 'y': y}
    
    # Отправляем в прокси
    try:
        import requests
        response = requests.post(
            'http://localhost:5000/api/village',
            json={'id': village_id, 'x': x, 'y': y, 'name': name or f"Village {village_id}"},
            timeout=5
        )
        
        if response.status_code == 200:
            await ctx.send(f"✅ Координаты деревни {village_id} установлены: ({x}, {y}) и отправлены в прокси")
        else:
            await ctx.send(f"✅ Координаты деревни {village_id} установлены локально: ({x}, {y})\n⚠️ Прокси недоступен")
    except:
        await ctx.send(f"✅ Координаты деревни {village_id} установлены локально: ({x}, {y})\n⚠️ Прокси недоступен")

@bot.command(name='addvillages')
async def add_multiple_villages(ctx):
    """
    Добавить несколько деревень для тестирования
    """
    test_villages = [
        (6515, 100, 200, "Test Village 1"),
        (74000, 150, 180, "Test Village 2"),
        (71593, 120, 220, "Test Village 3"),
        (93485, 180, 160, "Test Village 4"),
        (45594, 90, 190, "Test Village 5"),
        (90618, 200, 250, "Target Village"),
    ]
    
    added = 0
    for vid, x, y, name in test_villages:
        village_coords[vid] = {'x': x, 'y': y}
        try:
            import requests
            requests.post(
                'http://localhost:5000/api/village',
                json={'id': vid, 'x': x, 'y': y, 'name': name},
                timeout=2
            )
            added += 1
        except:
            pass
    
    await ctx.send(f"✅ Добавлено {added} тестовых деревень")

@tasks.loop(seconds=30)
async def check_attacks():
    """Проверка атак каждые 30 секунд"""
    now = datetime.now()
    to_remove = []
    
    for attack_id, data in attacks.items():
        time_until = (data['arrival_time'] - now).total_seconds()
        
        # Уведомление за 5 минут
        if 270 <= time_until <= 300 and not data['notified_5min']:
            channel = bot.get_channel(data['channel_id'])
            if channel:
                embed = discord.Embed(
                    title="⚠️ Атака через 5 минут!",
                    description=f"**Цель:** {data['village_name']} (ID: {data['target_village_id']})\n**Описание:** {data['description']}",
                    color=discord.Color.orange()
                )
                embed.add_field(name="Время прибытия", value=data['arrival_time'].strftime('%H:%M'))
                await channel.send("@here", embed=embed)
            data['notified_5min'] = True
        
        # Уведомление за 1 минуту
        if 50 <= time_until <= 70 and not data['notified_1min']:
            channel = bot.get_channel(data['channel_id'])
            if channel:
                embed = discord.Embed(
                    title="🚨 АТАКА ЧЕРЕЗ 1 МИНУТУ!",
                    description=f"**Цель:** {data['village_name']} (ID: {data['target_village_id']})\n**Описание:** {data['description']}",
                    color=discord.Color.dark_red()
                )
                embed.add_field(name="Время прибытия", value=data['arrival_time'].strftime('%H:%M'))
                await channel.send("@here", embed=embed)
            data['notified_1min'] = True
        
        # Удаляем прошедшие атаки
        if time_until < -60:
            to_remove.append(attack_id)
    
    for attack_id in to_remove:
        del attacks[attack_id]

@check_attacks.before_loop
async def before_check_attacks():
    await bot.wait_until_ready()

if __name__ == '__main__':
    bot.run(TOKEN)
