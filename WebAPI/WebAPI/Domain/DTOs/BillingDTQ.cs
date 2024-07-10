using System.Text.Json.Serialization;

namespace WebAPI.Domain.Model
{
    public class BillingDTQ
    {
        [JsonPropertyName("invoice_number")]
        public string InvoiceNumber { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; } = DateTime.UtcNow;
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }
        public string Currency { get; set; }
        public List<BillingLineDTO> Lines { get; set; } = new List<BillingLineDTO>();
    }
}
