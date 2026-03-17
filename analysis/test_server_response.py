"""
Тестирует ответ сервера на наш запрос
Показывает детали ошибки
"""
import subprocess
import re

print("="*60)
print("ТЕСТ ОТВЕТА СЕРВЕРА")
print("="*60)
print()

print("Запуск SimpleGameClient...")
print()

try:
    result = subprocess.run(
        ['StrongholdKingdoms\\bin\\Debug\\SimpleGameClient.exe'],
        capture_output=True,
        text=True,
        timeout=30,
        encoding='utf-8',
        errors='replace'
    )
    
    output = result.stdout
    
    # Ищем XML ответ
    if '<?xml' in output:
        print("✅ Получен XML ответ от сервера")
        print()
        
        # Извлекаем XML
        xml_start = output.find('<?xml')
        xml_end = output.find('</html>') + 7
        
        if xml_start != -1 and xml_end > xml_start:
            xml_content = output[xml_start:xml_end]
            
            # Ищем ключевые фразы
            if 'Runtime Error' in xml_content:
                print("❌ Сервер вернул Runtime Error")
                print()
                
                # Пробуем найти детали ошибки
                if 'Description:' in xml_content:
                    desc_start = xml_content.find('Description:')
                    desc_end = xml_content.find('</p>', desc_start)
                    if desc_end > desc_start:
                        description = xml_content[desc_start:desc_end]
                        # Убираем HTML теги
                        description = re.sub('<[^<]+?>', '', description)
                        print("Описание ошибки:")
                        print(description)
                        print()
                
                print("Это означает:")
                print("1. Наш запрос ДОХОДИТ до сервера ✅")
                print("2. Сервер его ОБРАБАТЫВАЕТ ✅")
                print("3. Но что-то в запросе неправильно ❌")
                print()
                print("Возможные причины:")
                print("- Неправильные параметры LoginUserGuid")
                print("- Неправильный формат данных")
                print("- Нужна дополнительная авторизация")
                print("- Нужен другой метод перед LoginUserGuid")
                print()
                print("РЕКОМЕНДАЦИЯ:")
                print("Используй Wireshark для анализа трафика оригинальной игры")
                print("Инструкция: QUICK_START_WIRESHARK.md")
            
            # Сохраняем XML в файл
            with open('server_error.html', 'w', encoding='utf-8') as f:
                f.write(xml_content)
            print()
            print("✅ XML ответ сохранен в server_error.html")
    
    else:
        print("❌ XML ответ не найден в выводе")
        print()
        print("Вывод программы:")
        print(output[:500])

except subprocess.TimeoutExpired:
    print("❌ Таймаут выполнения")
except Exception as e:
    print(f"❌ Ошибка: {e}")

print()
print("="*60)
