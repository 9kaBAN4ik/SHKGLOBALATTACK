using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;

namespace CustomSinks
{
    /// <summary>
    /// Базовый класс для custom sinks
    /// </summary>
    public abstract class BaseCustomSink : IClientChannelSink
    {
        protected IClientChannelSink NextChannelSink { get; private set; }

        protected BaseCustomSink(IClientChannelSink nextSink)
        {
            NextChannelSink = nextSink;
        }

        public IClientChannelSink NextSink
        {
            get { return NextChannelSink; }
        }

        public IDictionary Properties
        {
            get { return null; }
        }

        public abstract void ProcessMessage(IMessage msg, ITransportHeaders requestHeaders,
            Stream requestStream, out ITransportHeaders responseHeaders, out Stream responseStream);

        public abstract void AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage msg,
            ITransportHeaders headers, Stream stream);

        public abstract void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, object state,
            ITransportHeaders headers, Stream stream);

        public Stream GetRequestStream(IMessage msg, ITransportHeaders headers)
        {
            return null;
        }

        // Реализация интерфейса IClientChannelSink
        void IClientChannelSink.ProcessMessage(IMessage msg, ITransportHeaders requestHeaders,
            Stream requestStream, out ITransportHeaders responseHeaders, out Stream responseStream)
        {
            ProcessMessage(msg, requestHeaders, requestStream, out responseHeaders, out responseStream);
        }

        void IClientChannelSink.AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage msg,
            ITransportHeaders headers, Stream stream)
        {
            AsyncProcessRequest(sinkStack, msg, headers, stream);
        }

        void IClientChannelSink.AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, object state,
            ITransportHeaders headers, Stream stream)
        {
            AsyncProcessResponse(sinkStack, state, headers, stream);
        }

        Stream IClientChannelSink.GetRequestStream(IMessage msg, ITransportHeaders headers)
        {
            return GetRequestStream(msg, headers);
        }

        IClientChannelSink IClientChannelSink.NextChannelSink
        {
            get { return NextChannelSink; }
        }

        IDictionary IChannelSinkBase.Properties
        {
            get { return Properties; }
        }
    }
}
