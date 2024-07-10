using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.Model
{
    public class BillingLine
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = new Product();
        public string Description { get; set; }
        public int Quantity { get; set; }
        [JsonPropertyName("unit_price")]
        public int UnitPrice { get; set; }
        public int Subtotal { get; set; }

        [JsonIgnore]
        public Guid BillingId { get; set; }
        [JsonIgnore]
        public Billing Billing { get; set; }
    }
}
