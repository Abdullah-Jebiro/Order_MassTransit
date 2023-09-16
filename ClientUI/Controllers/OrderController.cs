using MassTransit;
using Messages;
using Microsoft.AspNetCore.Mvc;

namespace ClientUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
       

        private readonly ILogger<OrderController> _logger;
        private readonly IBus _bus;

        public OrderController(ILogger<OrderController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }


        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var sendToUri = new Uri($"{RabbitMqConsts.RabbitMqUri}{RabbitMqConsts.SalesServiceQueue}");
            var endPoint = await _bus.GetSendEndpoint(sendToUri);
            await endPoint.Send(new PlaceOrder());
            return NoContent();
        }
    }
}