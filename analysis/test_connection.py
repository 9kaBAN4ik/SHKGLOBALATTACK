"""
Тест подключения к серверу Stronghold Kingdoms
"""
import requests
from dotenv import load_dotenv
import os

load_dotenv()

server_url = os.getenv('shk_link')
print(f"Тестируем подключение к: {server_url}")

# Попробуем разные endpoints
endpoints = [
    "/",
    "/KingdomsRPC/Kingdoms.rem",
    "/api/villages",
    "/villages",
]

for endpoint in endpoints:
    url = f"{server_url}{endpoint}"
    print(f"\nПробуем: {url}")
    
    try:
        # GET запрос
        response = requests.get(url, timeout=5)
        print(f"  GET Status: {response.status_code}")
        print(f"  Content-Type: {response.headers.get('content-type', 'unknown')}")
        print(f"  Content (first 200 chars): {response.text[:200]}")
    except Exception as e:
        print(f"  GET Error: {e}")
    
    try:
        # POST запрос
        response = requests.post(url, timeout=5)
        print(f"  POST Status: {response.status_code}")
    except Exception as e:
        print(f"  POST Error: {e}")

print("\n" + "="*50)
print("Вывод: Сервер использует .NET Remoting, нужен специальный клиент")
