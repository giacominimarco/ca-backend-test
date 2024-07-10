using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Service
{
    public interface ICustomerService
    {
        public Task<Customer> Get(Guid id);
        public Task<List<Customer>> Customers();
        public bool Delete(Guid id);
        public Task<bool> Insert(Customer customer);
        public bool Update(Customer customer);
    }
}
