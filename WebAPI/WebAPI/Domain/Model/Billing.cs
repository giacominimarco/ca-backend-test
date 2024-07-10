using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Domain.Model
{
    public class Billing
    {
        [Unicode]
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonPropertyName("invoice_number")]
        public string InvoiceNumber { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }
        public string Currency { get; set; }
        public List<BillingLine> Lines { get; set; } = new List<BillingLine>();
    }
}
