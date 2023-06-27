namespace MessageBus
{
    public interface IMessageBus : IDisposable
    {
        public void Publish(string key, string message);
        public void Consume(string key, Func<string, Task> func);
    }
}
