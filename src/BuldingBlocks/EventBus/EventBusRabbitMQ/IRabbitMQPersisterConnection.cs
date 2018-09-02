using System;
using RabbitMQ.Client;

namespace EventBusRabbitMQ
{
    public interface IRabbitMqPersisterConnection : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
