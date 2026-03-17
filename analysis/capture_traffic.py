"""
Скрипт для перехвата и анализа трафика Stronghold Kingdoms
Запусти mitmproxy и этот скрипт для анализа запросов
"""
import mitmproxy.http
from mitmproxy import ctx
import json

class SHKInterceptor:
    def request(self, flow: mitmproxy.http.HTTPFlow):
        # Фильтруем только запросы к серверу игры
        if "fireflyops.com" in flow.request.pretty_host or "elb" in flow.request.pretty_host:
            ctx.log.info(f"=== REQUEST to {flow.request.pretty_url} ===")
            ctx.log.info(f"Method: {flow.request.method}")
            ctx.log.info(f"Headers: {flow.request.headers}")
            
            if flow.request.content:
                ctx.log.info(f"Content-Type: {flow.request.headers.get('content-type', 'unknown')}")
                ctx.log.info(f"Content length: {len(flow.request.content)}")
                
                # Сохраняем в файл для анализа
                with open("shk_request.bin", "wb") as f:
                    f.write(flow.request.content)
                ctx.log.info("Request saved to shk_request.bin")
    
    def response(self, flow: mitmproxy.http.HTTPFlow):
        if "fireflyops.com" in flow.request.pretty_host or "elb" in flow.request.pretty_host:
            ctx.log.info(f"=== RESPONSE from {flow.request.pretty_url} ===")
            ctx.log.info(f"Status: {flow.response.status_code}")
            
            if flow.response.content:
                ctx.log.info(f"Content length: {len(flow.response.content)}")
                
                # Сохраняем в файл для анализа
                with open("shk_response.bin", "wb") as f:
                    f.write(flow.response.content)
                ctx.log.info("Response saved to shk_response.bin")

addons = [SHKInterceptor()]
