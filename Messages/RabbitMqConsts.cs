using System.Windows.Input;

namespace Messages
{
    public class RabbitMqConsts
    {
        public const string RabbitMqUri = "rabbitmq://localhost/";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string SalesServiceQueue = "Sales.service";
        public const string ShippingServiceQueue = "Shipping.service";
        public const string BillingServiceQueue = "Billing.service";
    }
}