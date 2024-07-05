using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Model
{
    public class Billing
    {
        [Key]
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; } = DateTime.UtcNow;
        public int TotalAmount { get; set; }
        public string Currency { get; set; }
        public List<BillingLine> Lines { get; set; } = new List<BillingLine>();
    }
}
