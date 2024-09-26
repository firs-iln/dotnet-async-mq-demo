using EasyNetQ;
using Messages;

namespace Consumer;

class Program
{
    private static async Task Main(string[] args)
    {
        // create a connection instance
        using var bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");
        
        // subscribe to messages 
        await bus.PubSub.SubscribeAsync<TextMessage>("subscription_id", HandleTextMessage);
        
        Console.WriteLine("Consumer is running. Press any key to exit...");
        Console.ReadKey();
    }
    
    private static async Task HandleTextMessage(TextMessage message)
    {
        await Task.Delay(500);
        Console.WriteLine($"Received message: {message.Text}, ID: {message.Id}, Created At: {message.CreatedAt}");
    }
}