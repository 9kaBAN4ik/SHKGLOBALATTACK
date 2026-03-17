using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;

namespace CompressedSink
{
    /// <summary>
    /// Исправленная версия CompressedClientSink
    /// Оригинальная версия пыталась получить stream.Length на ConnectStream, что вызывало NotSupportedException
    /// </summary>
    public class CompressedClientSink : CustomSinks.BaseCustomSink
    {
        public CompressedClientSink(IClientChannelSink nextSink) : base(nextSink)
        {
        }

        public override void ProcessMessage(IMessage msg, ITransportHeaders requestHeaders, 
            Stream requestStream, out ITransportHeaders responseHeaders, out Stream responseStream)
        {
            // Сжимаем запрос
            if (requestStream != null && requestStream.CanRead)
            {
                Console.WriteLine($"[CompressedSink] Сжатие запроса (размер до: {requestStream.Length} байт)");
                requestStream = CompressStream(requestStream);
                requestHeaders["Content-Encoding"] = "gzip";
                Console.WriteLine($"[CompressedSink] Размер после сжатия: {requestStream.Length} байт");
            }

            // Отправляем через следующий sink
            NextChannelSink.ProcessMessage(msg, requestHeaders, requestStream, 
                out responseHeaders, out responseStream);

            // Распаковываем ответ
            if (responseStream != null && responseStream.CanRead)
            {
                Console.WriteLine($"[CompressedSink] Получен ответ");
                responseStream = DecompressStream(responseStream, responseHeaders);
            }
        }

        public override void AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage msg,
            ITransportHeaders headers, Stream stream)
        {
            // Сжимаем запрос
            if (stream != null && stream.CanRead)
            {
                stream = CompressStream(stream);
                headers["Content-Encoding"] = "gzip";
            }

            sinkStack.Push(this, null);
            NextChannelSink.AsyncProcessRequest(sinkStack, msg, headers, stream);
        }

        public override void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, object state,
            ITransportHeaders headers, Stream stream)
        {
            // Распаковываем ответ
            if (stream != null && stream.CanRead)
            {
                stream = DecompressStream(stream, headers);
            }

            sinkStack.AsyncProcessResponse(headers, stream);
        }

        private Stream CompressStream(Stream input)
        {
            if (input == null || !input.CanRead)
                return input;

            try
            {
                // Копируем входной поток в MemoryStream
                MemoryStream inputBuffer = new MemoryStream();
                input.CopyTo(inputBuffer);
                inputBuffer.Position = 0;

                // Сжимаем
                MemoryStream output = new MemoryStream();
                using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress, true))
                {
                    inputBuffer.CopyTo(gzip);
                }

                output.Position = 0;
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сжатия: {ex.Message}");
                return input;
            }
        }

        private Stream DecompressStream(Stream input, ITransportHeaders headers)
        {
            if (input == null || !input.CanRead)
                return input;

            try
            {
                // ИСПРАВЛЕНИЕ: Не используем stream.Length!
                // Вместо этого копируем поток в MemoryStream
                MemoryStream buffer = new MemoryStream();
                input.CopyTo(buffer);
                buffer.Position = 0;

                // Проверяем, это сжатые данные или нет
                // Проверяем GZIP magic number (1F 8B)
                byte[] header = new byte[5];
                int bytesRead = buffer.Read(header, 0, 5);
                buffer.Position = 0;

                // Проверяем на XML (<?xml)
                if (bytesRead >= 5 && header[0] == 0x3C && header[1] == 0x3F && header[2] == 0x78)
                {
                    // Это XML ответ - выводим для отладки
                    Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║           XML ОТВЕТ ОТ СЕРВЕРА (ОШИБКА)                   ║");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                    
                    StreamReader reader = new StreamReader(buffer);
                    string xmlContent = reader.ReadToEnd();
                    Console.WriteLine(xmlContent);
                    Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
                    
                    buffer.Position = 0;
                    return buffer;
                }

                bool isGzipped = (bytesRead >= 2 && header[0] == 0x1F && header[1] == 0x8B);

                // Также проверяем заголовок Content-Encoding
                string contentEncoding = headers != null ? headers["Content-Encoding"] as string : null;
                if (!string.IsNullOrEmpty(contentEncoding) && contentEncoding.ToLower().Contains("gzip"))
                {
                    isGzipped = true;
                }

                if (!isGzipped)
                {
                    // Не сжато - возвращаем как есть
                    return buffer;
                }

                // Распаковываем
                MemoryStream output = new MemoryStream();
                using (GZipStream gzip = new GZipStream(buffer, CompressionMode.Decompress, true))
                {
                    gzip.CopyTo(output);
                }

                output.Position = 0;
                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка распаковки: {ex.Message}");
                
                // Если не удалось распаковать, возвращаем оригинальный поток
                if (input.CanSeek)
                {
                    input.Position = 0;
                    return input;
                }
                
                // Если поток не поддерживает Seek, возвращаем буфер
                MemoryStream buffer = new MemoryStream();
                input.CopyTo(buffer);
                buffer.Position = 0;
                return buffer;
            }
        }
    }
}
