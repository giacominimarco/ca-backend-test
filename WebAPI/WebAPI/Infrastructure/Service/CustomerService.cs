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

        public bool Delete(Guid id)
        {
            return _customerRepository.Delete(id);
        }

        public Task<Customer> Get(Guid id)
        {
            return _customerRepository.Get(id);
        }

        public Task<List<Customer>> Customers()
        {
            return _customerRepository.Customers();
        }

        public async Task<bool> Insert(Customer customer)
        {
            Customer answerCustomer = await _customerRepository.Get(customer.Id);
            if (answerCustomer is null)
                return await _customerRepository.Insert(customer);
            return true;
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
    }
}
