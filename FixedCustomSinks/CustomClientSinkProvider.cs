using System;
using System.Collections;
using System.Runtime.Remoting.Channels;
using CompressedSink;

namespace CustomSinks
{
    /// <summary>
    /// Provider для создания custom sinks
    /// </summary>
    public class CustomClientSinkProvider : IClientChannelSinkProvider
    {
        private IClientChannelSinkProvider _next;
        private IDictionary _properties;
        private ICollection _providerData;

        public CustomClientSinkProvider()
        {
        }

        public CustomClientSinkProvider(IDictionary properties, ICollection providerData)
        {
            _properties = properties;
            _providerData = providerData;
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

            // Определяем тип sink из properties
            string sinkType = _properties != null ? _properties["customSinkType"] as string : null;

            if (string.IsNullOrEmpty(sinkType))
            {
                sinkType = "CompressedSink.CompressedClientSink, CustomSinks";
            }

            // Создаем CompressedClientSink
            if (sinkType.Contains("CompressedClientSink"))
            {
                return new CompressedClientSink(nextSink);
            }

            // По умолчанию возвращаем CompressedClientSink
            return new CompressedClientSink(nextSink);
        }
    }
}
