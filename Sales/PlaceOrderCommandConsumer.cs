using MassTransit;
using Messages;

namespace Sales
{


    public class PlaceOrderCommandConsumer : IConsumer<PlaceOrder>
    {

        public async Task Consume(ConsumeContext<PlaceOrder> context)
        {
            var message = context.Message;
            await Console.Out.WriteLineAsync($"Received PlaceOrder, OrderId = {message.OrderId}" +
                $" , UserId = {message.UserId}");

            await context.Publish(new OrderPlaced
            {
                OrderId = message.OrderId,
                UserId = message.UserId,
            });

        }
    }
}
