namespace ES_Backend.Models
{
    public class OrderDetailsModel
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}
