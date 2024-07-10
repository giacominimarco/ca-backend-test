using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public interface IBillingRepository
    {
        public Task<Billing> Get(Guid id);
        public Task<List<Billing>> GetBillings();
        public bool Delete(Guid id);
        public Task<bool> Insert(Billing billing);
        public bool Update(Billing billing);
    }
}
