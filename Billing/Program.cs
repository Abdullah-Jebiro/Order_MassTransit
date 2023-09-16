using MassTransit;
using Messages;

Console.Title = "Billing";

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), h =>
    {
        h.Username(RabbitMqConsts.UserName);
        h.Password(RabbitMqConsts.Password);
    });
    cfg.ReceiveEndpoint(RabbitMqConsts.BillingServiceQueue, ep =>
    {

        ep.Consumer<OrderPlacedEventConsumer>();
    });

});



bus.StartAsync();

Console.WriteLine("Listening for Register Demand commands.. \n" +
    "Press enter to exit");
Console.ReadLine();

bus.StopAsync();
