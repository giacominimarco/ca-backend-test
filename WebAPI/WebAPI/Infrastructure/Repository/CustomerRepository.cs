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

        public bool Delete(int id)
        {
            _connectionContext.Customers.RemoveRange(new Customer[id]);
            _connectionContext.SaveChanges();
            return true;
        }

        public Task<Customer> Get(int id)
        {
            //return _connectionContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            throw new NotImplementedException();
        }

        public Task<List<Customer>> Customers()
        {
            return _connectionContext.Customers.ToListAsync();
        }

        public bool Insert(Customer customer)
        {
            _connectionContext.Customers.Add(customer);
            _connectionContext.SaveChanges();
            return true;
        }

        public bool Update(Customer customer)
        {
            _connectionContext.Customers.Update(customer);
            _connectionContext.SaveChanges();
            return true;
        }
    }
}
