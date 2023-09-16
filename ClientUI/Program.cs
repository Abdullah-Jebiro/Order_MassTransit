using MassTransit;
using Messages;

var builder = WebApplication.CreateBuilder(args);


#region Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion




#region Add services MassTransit
builder.Services.AddMassTransit(cfg =>
{
    cfg.UsingRabbitMq((context, config) =>
    {
        config.Host(new Uri(RabbitMqConsts.RabbitMqUri), h =>
        {
            h.Username(RabbitMqConsts.UserName);
            h.Password(RabbitMqConsts.Password);
        });
    });
});
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
