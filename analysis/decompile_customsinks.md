# План исправления CustomSinks.dll

## Проблема

Ошибка в `CompressedSink.CompressedClientSink.ProcessResponse`:
```
в System.Net.ConnectStream.get_Length()
в System.IO.BufferedStream.get_Length()
в CompressedSink.CompressedClientSink.ProcessResponse(...)
```

`ConnectStream` не поддерживает свойство `Length`, потому что это сетевой поток.

## Решение

Нужно исправить метод `ProcessResponse`, чтобы он НЕ обращался к `stream.Length`.

### Вариант 1: Декомпиляция и исправление

1. Использовать ILSpy или dnSpy для декомпиляции CustomSinks.dll
2. Найти метод `CompressedClientSink.ProcessResponse`
3. Заменить код, который использует `stream.Length`
4. Перекомпилировать DLL

### Вариант 2: Создать свою реализацию

Создать новую DLL с правильной реализацией CompressedClientSink.

## Типичный баг в ProcessResponse

```csharp
// НЕПРАВИЛЬНО:
public void ProcessResponse(IMessage message, ITransportHeaders headers, 
    ref Stream stream, object state)
{
    long length = stream.Length; // ❌ ConnectStream не поддерживает Length!
    
    if (length > 0)
    {
        // Распаковка...
    }
}
```

```csharp
// ПРАВИЛЬНО:
public void ProcessResponse(IMessage message, ITransportHeaders headers, 
    ref Stream stream, object state)
{
    // Проверяем заголовок Content-Encoding вместо длины
    string contentEncoding = headers["Content-Encoding"] as string;
    
    if (!string.IsNullOrEmpty(contentEncoding) && 
        contentEncoding.ToLower().Contains("gzip"))
    {
        // Копируем поток в MemoryStream
        MemoryStream ms = new MemoryStream();
        stream.CopyTo(ms);
        ms.Position = 0;
        
        // Распаковываем
        using (GZipStream gzip = new GZipStream(ms, CompressionMode.Decompress))
        {
            MemoryStream output = new MemoryStream();
            gzip.CopyTo(output);
            output.Position = 0;
            stream = output;
        }
    }
}
```

## Следующие шаги

1. Скачать ILSpy: https://github.com/icsharpcode/ILSpy/releases
2. Открыть CustomSinks.dll
3. Найти CompressedClientSink.ProcessResponse
4. Экспортировать код в C#
5. Исправить баг
6. Создать новый проект и скомпилировать
7. Заменить DLL в SimpleGameClient

## Альтернатива: Использовать Reflector или dnSpy

dnSpy позволяет редактировать IL код напрямую без перекомпиляции.
