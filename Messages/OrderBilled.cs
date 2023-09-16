namespace Messages
{
    public class OrderBilled 
    {
        public string OrderId { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}