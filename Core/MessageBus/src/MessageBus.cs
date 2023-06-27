using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IModel _channel;

        public MessageBus()
        {
            var factory = new ConnectionFactory { HostName = "localhost", Port = 5672 };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            this._channel = channel;

            this._channel.QueueDeclare(queue: MessageKeys.POST_CREATED,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);
        }

        public void Publish(string key, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            this._channel.BasicPublish(exchange: string.Empty,
                                 routingKey: key,
                                 basicProperties: null,
                                 body: body);
        }

        public void Consume(string key, Func<string, Task> func)
        {
            var consumer = new EventingBasicConsumer(this._channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                func.Invoke(message);
            };

            this._channel.BasicConsume(queue: key, autoAck: true, consumer: consumer);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}