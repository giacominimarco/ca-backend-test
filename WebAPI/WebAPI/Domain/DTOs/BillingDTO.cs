using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Model
{
    public class BillingDTO
    {
        public string Invoice_Number { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public DateTime Due_Date { get; set; } = DateTime.UtcNow;
        public int Total_Amount { get; set; }
        public string Currency { get; set; }
        public List<BillingLineDTO> Lines { get; set; } = new List<BillingLineDTO>();
    }
}
