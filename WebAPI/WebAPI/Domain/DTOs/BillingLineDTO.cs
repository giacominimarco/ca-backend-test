using System.Text.Json.Serialization;

namespace WebAPI.Domain.Model
{
    public class BillingLineDTO
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [JsonPropertyName("unit_price")]
        public int UnitPrice { get; set; }
        public int Subtotal { get; set; }
    }
}
