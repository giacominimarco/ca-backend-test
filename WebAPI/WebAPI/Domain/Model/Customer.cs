using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Model
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
