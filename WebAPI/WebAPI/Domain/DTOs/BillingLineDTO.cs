namespace WebAPI.Domain.Model
{
    public class BillingLineDTO
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Unit_Price { get; set; }
        public int Subtotal { get; set; }
    }
}
