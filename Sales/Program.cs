using MassTransit;
using Messages;
using Sales;

Console.Title = "Sales";

var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), h =>
    {
        h.Username(RabbitMqConsts.UserName);
        h.Password(RabbitMqConsts.Password);
    });
    cfg.ReceiveEndpoint(RabbitMqConsts.SalesServiceQueue, ep =>
    {
     
        ep.Consumer<PlaceOrderCommandConsumer>();
    });

});



bus.StartAsync();

Console.WriteLine("Listening for Register Demand commands.. \n" +
    "Press enter to exit");
Console.ReadLine();

bus.StopAsync();
