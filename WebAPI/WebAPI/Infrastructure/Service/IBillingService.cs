using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Service
{
    public interface IBillingService
    {
        public Task<Billing> Get(Guid id);
        public Task<List<Billing>> GetBillings();
        public bool Delete(Guid id);
        public Task<bool> Insert(Billing product);
        public bool Update(Billing product);
    }
}