namespace ES_Backend.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int Price { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMode { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}
