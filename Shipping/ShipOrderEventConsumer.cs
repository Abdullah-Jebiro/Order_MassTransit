using MassTransit;
using Messages;


public class ShipOrderEventConsumer : 
    IConsumer<OrderPlaced>,
    IConsumer<OrderBilled>
{
    public async Task Consume(ConsumeContext<OrderPlaced> context)
    {
        await Console.Out.WriteLineAsync($"OrderPlaced message received.");
    }

    public async Task Consume(ConsumeContext<OrderBilled> context)
    {
        await Console.Out.WriteLineAsync($"OrderBilled message received."); ;
    }
}


