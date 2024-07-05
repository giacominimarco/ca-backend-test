using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly ConnectionContext _connectionContext;
        public BillingRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public bool Delete(Guid id)
        {
            _connectionContext.Billings.RemoveRange(new Billing { Id = id });
            _connectionContext.SaveChanges();
            return true;
        }

        public Task<Billing> Get(Guid id)
        {
            return _connectionContext.Billings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Billing>> GetBillings()
        {
            return _connectionContext.Billings.ToListAsync();
        }

        public bool Insert(Billing billing)
        {
            _connectionContext.Billings.Add(billing);
            _connectionContext.SaveChanges();
            return true;
        }

        public bool Update(Billing billing)
        {
            _connectionContext.Billings.Update(billing);
            _connectionContext.SaveChanges();
            return true;
        }
    }
}
