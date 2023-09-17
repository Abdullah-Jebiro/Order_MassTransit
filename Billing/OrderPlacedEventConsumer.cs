using MassTransit;
using Messages;

public class OrderPlacedEventConsumer : IConsumer<OrderPlaced>
{
    public async Task Consume(ConsumeContext<OrderPlaced> context)
    {
        var message = context.Message;
        await Console.Out.WriteLineAsync($"Received OrderPlaced, " +
            $"OrderId = {message.OrderId} , UserId = {message.UserId} - Charging credit card...");
        await context.Publish(new OrderBilled
        {
            OrderId = message.OrderId,
            UserId = message.UserId,
        });
    }
}