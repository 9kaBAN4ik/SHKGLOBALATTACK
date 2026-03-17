# Добавь эту команду в bot.py перед check_attacks

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
        
        # TODO: Получить координаты деревень с сервера
        # Пока используем тестовые данные
        
        # Создаем embed с результатами
        embed = discord.Embed(
            title=f"⚔️ Расчет времени атак",
            description=f"**Цель:** Деревня #{target_village}\n**Тип:** {attack_type}",
            color=discord.Color.blue()
        )
        
        # Таблица результатов
        table = "```\n"
        table += "+-------------+----------+\n"
        table += "| Village_id  | Cap x4   |\n"
        table += "+-------------+----------+\n"
        
        for village in attacking_villages:
            village_id = village['village_id']
            count = village['count']
            
            # TODO: Получить реальные координаты и рассчитать время
            # Пока используем случайное время для демонстрации
            import random
            hours = random.randint(1, 2)
            minutes = random.randint(10, 50)
            seconds = random.randint(0, 59)
            
            table += f"| {village_id:>6}[{count}]  | {hours}h:{minutes}m:{seconds}s |\n"
        
        table += "+-------------+----------+\n"
        table += "```"
        
        embed.add_field(name="Время прибытия", value=table, inline=False)
        embed.set_footer(text="⚠️ Для точного расчета нужно подключение к серверу игры")
        
        await ctx.send(embed=embed)
        
    except Exception as e:
        await ctx.send(f"❌ Ошибка: {str(e)}")

@bot.command(name='coords')
async def set_village_coords(ctx, village_id: int, x: int, y: int):
    """
    Установить координаты деревни (временно, пока нет подключения к серверу)
    Пример: !coords 6515 100 200
    """
    village_coords[village_id] = {'x': x, 'y': y}
    await ctx.send(f"✅ Координаты деревни {village_id} установлены: ({x}, {y})")
