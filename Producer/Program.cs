using EasyNetQ;
using Messages;

namespace Producer;

class Program
{
    static async Task Main(string[] args)
    {
        // create a connection instance
        using var bus = RabbitHutch.CreateBus("host=localhost");

        Console.WriteLine("Publisher is running.");

        // publish a message
        var message = new TextMessage
        {
            Id = Guid.NewGuid(),
            Text = "Hello, RabbitMQ!",
            CreatedAt = DateTime.Now
        };
        await bus.PubSub.PublishAsync(message);

        Console.WriteLine("Message published.");
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}