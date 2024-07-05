using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Domain.Model
{
    public class BillingLine
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Subtotal { get; set; }
    }
}
