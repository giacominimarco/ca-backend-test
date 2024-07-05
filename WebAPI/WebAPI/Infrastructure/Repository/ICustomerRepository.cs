using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public interface ICustomerRepository
    {
        public Task<Customer> Get(int id);
        public Task<List<Customer>> Customers();
        public bool Delete(int id);
        public bool Insert(Customer customer);
        public bool Update(Customer customer);
    }
}
