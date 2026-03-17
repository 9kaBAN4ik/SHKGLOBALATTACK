#!/usr/bin/env python3
"""
Главный запускаемый файл проекта SHKGLOBALATTACK
Запускает прокси-сервер, который предоставляет REST API для Discord бота
"""
import subprocess
import sys
import os
from dotenv import load_dotenv

# Загружаем переменные окружения
load_dotenv()

def print_header():
    """Вывести заголовок"""
    print("\n" + "=" * 70)
    print("🎮 SHKGLOBALATTACK - Stronghold Kingdoms Discord Bot")
    print("=" * 70)
    print()

def print_status():
    """Вывести статус конфигурации"""
    print("📋 Конфигурация:")
    print(f"   ✅ Игровой сервер: {os.getenv('shk_link', 'Не установлено')}")
    print(f"   ✅ Игровой Email: {os.getenv('GAME_EMAIL', 'Не установлено')}")
    print(f"   {'✅' if os.getenv('BOT_TOKEN') else '❌'} Discord Bot Token: {'Установлен' if os.getenv('BOT_TOKEN') else 'Не установлен'}")
    print()

def print_instructions():
    """Вывести инструкции"""
    print("📖 Что работает в проекте:")
    print("   ✅ REST API прокси-сервер (Python)")
    print("   ✅ Discord бот с командами управления атаками")
    print("   ✅ Калькулятор времени атак")
    print("   ✅ Тест авторизации в игре (XML-RPC)")
    print()
    print("❌ Что НЕ работает:")
    print("   ❌ Автоматическое получение координат из игры (.NET Remoting)")
    print("   → Координаты нужно добавлять вручную через API или Discord команды")
    print()
    print("🚀 Как использовать:")
    print()
    print("1. ЗАПУСТИТЬ ПРОКСИ-СЕРВЕР (этот терминал):")
    print("   python main.py")
    print()
    print("2. ЗАПУСТИТЬ DISCORD БОТА (в другом терминале):")
    print("   cd analysis && python bot.py")
    print()
    print("3. ИСПОЛЬЗОВАТЬ В DISCORD:")
    print("   !ping                  - Проверить работу бота")
    print("   !следить 12345 Название - Отслеживать деревню")
    print("   !time capx4 6515[1];74000[2] 90618 - Рассчитать время атак")
    print()
    print("4. ДОБАВИТЬ КООРДИНАТЫ ВРУЧНУЮ (через API):")
    print("   curl -X POST http://localhost:5000/api/village \\")
    print("        -H 'Content-Type: application/json' \\")
    print("        -d '{\"id\": 12345, \"x\": 100, \"y\": 200, \"name\": \"Village\"}'")
    print()
    print("5. ТЕСТИРОВАТЬ АВТОРИЗАЦИЮ:")
    print("   cd analysis && python test_login.py")
    print()
    print("=" * 70)
    print()

def start_proxy():
    """Запустить прокси-сервер"""
    print("🚀 Запуск REST API прокси-сервера...")
    print()
    
    try:
        # Запускаем прокси-сервер
        subprocess.run([sys.executable, 'proxy_server.py'], check=True)
    except KeyboardInterrupt:
        print("\n\n⏹️  Прокси-сервер остановлен пользователем")
    except Exception as e:
        print(f"\n❌ Ошибка запуска: {e}")
        sys.exit(1)

def main():
    """Главная функция"""
    print_header()
    print_status()
    print_instructions()
    
    # Спрашиваем пользователя
    response = input("Запустить прокси-сервер сейчас? (y/n): ").strip().lower()
    
    if response == 'y' or response == 'yes' or response == '':
        start_proxy()
    else:
        print("\n💡 Для запуска выполните: python main.py")
        print("💡 Или напрямую: python proxy_server.py")

if __name__ == '__main__':
    main()
