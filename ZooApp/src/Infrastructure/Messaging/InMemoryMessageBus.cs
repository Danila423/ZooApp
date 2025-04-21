using System;

namespace ZooApp.Infrastructure.Messaging
{
    public class InMemoryMessageBus
    {
        public void Publish<T>(T @event) where T : class
        {
            Console.WriteLine($"Event published: {@event}");
        }
    }
}
