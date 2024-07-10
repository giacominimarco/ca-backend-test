using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public interface ICustomerRepository
    {
        public Task<Customer> Get(Guid id);
        public Task<List<Customer>> Customers();
        public bool Delete(Guid id);
        public Task<bool> Insert(Customer customer);
        public bool Update(Customer customer);
    }
}
