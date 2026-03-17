using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;

namespace SHKGameConnector
{
    // Исправленная версия CompressedClientSink
    public class FixedCompressedClientSink : IClientChannelSink
    {
        private IClientChannelSink _nextSink;

        public FixedCompressedClientSink(IClientChannelSink nextSink)
        {
            _nextSink = nextSink;
        }

        public IClientChannelSink NextChannelSink
        {
            get { return _nextSink; }
        }

        public IDictionary Properties
        {
            get { return null; }
        }

        public void AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage msg,
            ITransportHeaders headers, Stream stream)
        {
            // Сжимаем запрос
            Stream compressedStream = CompressStream(stream);
            headers["Content-Encoding"] = "gzip";
            
            sinkStack.Push(this, null);
            _nextSink.AsyncProcessRequest(sinkStack, msg, headers, compressedStream);
        }

        public void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, object state,
            ITransportHeaders headers, Stream stream)
        {
            // Распаковываем ответ
            Stream decompressedStream = DecompressStream(stream);
            sinkStack.AsyncProcessResponse(headers, decompressedStream);
        }

        public Stream GetRequestStream(IMessage msg, ITransportHeaders headers)
        {
            return null;
        }

        public void ProcessMessage(IMessage msg, ITransportHeaders requestHeaders, Stream requestStream,
            out ITransportHeaders responseHeaders, out Stream responseStream)
        {
            // НЕ сжимаем запрос - отправляем как есть
            // requestHeaders["Content-Encoding"] = "gzip";
            
            // Отправляем через следующий sink
            _nextSink.ProcessMessage(msg, requestHeaders, requestStream,
                out responseHeaders, out responseStream);
            
            // Проверяем, сжат ли ответ
            string contentEncoding = responseHeaders["Content-Encoding"] as string;
            
            // Распаковываем ответ только если он сжат
            if (responseStream != null && responseStream.CanRead && 
                !string.IsNullOrEmpty(contentEncoding) && contentEncoding.ToLower().Contains("gzip"))
            {
                responseStream = DecompressStream(responseStream);
            }
        }

        private Stream CompressStream(Stream input)
        {
            if (input == null || !input.CanRead)
                return input;

            try
            {
                MemoryStream output = new MemoryStream();
                
                using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress, true))
                {
                    input.CopyTo(gzip);
                }
                
                output.Position = 0;
                return output;
            }
            catch
            {
                return input;
            }
        }

        private Stream DecompressStream(Stream input)
        {
            if (input == null || !input.CanRead)
                return input;

            try
            {
                // Сначала копируем поток в MemoryStream
                MemoryStream buffer = new MemoryStream();
                input.CopyTo(buffer);
                buffer.Position = 0;
                
                // Проверяем, начинается ли с XML
                byte[] header = new byte[5];
                buffer.Read(header, 0, 5);
                buffer.Position = 0;
                
                string headerStr = System.Text.Encoding.ASCII.GetString(header);
                if (headerStr == "<?xml")
                {
                    // Это XML ответ - выводим его для отладки
                    StreamReader reader = new StreamReader(buffer);
                    string xmlContent = reader.ReadToEnd();
                    
                    Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║           XML ОТВЕТ ОТ ИГРОВОГО СЕРВЕРА                    ║");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                    
                    // Выводим весь XML
                    Console.WriteLine(xmlContent);
                    
                    Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
                    
                    // Возвращаем поток в начало
                    buffer.Position = 0;
                    return buffer;
                }
                
                // Пробуем распаковать
                MemoryStream output = new MemoryStream();
                
                using (GZipStream gzip = new GZipStream(buffer, CompressionMode.Decompress))
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
                    input.Position = 0;
                return input;
            }
        }
    }

    // Provider для нашего исправленного sink
    public class FixedCompressedSinkProvider : IClientChannelSinkProvider
    {
        private IClientChannelSinkProvider _next;

        public FixedCompressedSinkProvider()
        {
        }

        public IClientChannelSinkProvider Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public IClientChannelSink CreateSink(IChannelSender channel, string url, object remoteChannelData)
        {
            IClientChannelSink nextSink = null;
            
            if (_next != null)
            {
                nextSink = _next.CreateSink(channel, url, remoteChannelData);
            }
            
            return new FixedCompressedClientSink(nextSink);
        }
    }
}
