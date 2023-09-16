using MassTransit;
using Messages;

Console.Title = "Shipping";

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), h =>
    {
        h.Username(RabbitMqConsts.UserName);
        h.Password(RabbitMqConsts.Password);
    });
    cfg.ReceiveEndpoint(RabbitMqConsts.ShippingServiceQueue, ep =>
    {

        ep.Consumer<ShipOrderEventConsumer>();
    });

});



bus.StartAsync();

Console.WriteLine("Listening for Register Demand commands.. \n" +"Press enter to exit");
Console.ReadLine();

bus.StopAsync();