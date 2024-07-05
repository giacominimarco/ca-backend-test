using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Repository;

namespace WebAPI.Infrastructure.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }

        public Task<Customer> Get(int id)
        {
            return _customerRepository.Get(id);
        }

        public Task<List<Customer>> Customers()
        {
            return _customerRepository.Customers();
        }

        public bool Insert(Customer customer)
        {
            return _customerRepository.Insert(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
    }
}
