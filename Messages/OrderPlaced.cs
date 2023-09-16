namespace Messages
{
    public class OrderPlaced 
    {
        public string OrderId { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}