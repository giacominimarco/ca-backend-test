using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ConnectionContext _connectionContext;
        public CustomerRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public bool Delete(Guid id)
        {
            _connectionContext.Customers.RemoveRange(new Customer { Id = id });
            _connectionContext.SaveChanges();
            return true;
        }

        public Task<Customer> Get(Guid id)
        {
            return _connectionContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Customer>> Customers()
        {
            return _connectionContext.Customers.ToListAsync();
        }

        public async Task<bool> Insert(Customer customer)
        {
            _connectionContext.Customers.Add(customer);
            _connectionContext.SaveChanges();
            return await Task.FromResult(true);
        }

        public bool Update(Customer customer)
        {
            _connectionContext.Customers.Update(customer);
            _connectionContext.SaveChanges();
            return true;
        }
    }
}
