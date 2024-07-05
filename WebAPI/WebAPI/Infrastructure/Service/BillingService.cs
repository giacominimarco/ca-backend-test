using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Repository;

namespace WebAPI.Infrastructure.Service
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;
        public BillingService(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public bool Delete(Guid id)
        {
            return _billingRepository.Delete(id);
        }

        public Task<Billing> Get(Guid id)
        {
            return _billingRepository.Get(id);
        }

        public Task<List<Billing>> GetBillings()
        {
            return _billingRepository.GetBillings();
        }

        public bool Insert(Billing billing)
        {
            return _billingRepository.Insert(billing);
        }

        public bool Update(Billing billing)
        {
            return _billingRepository.Update(billing);
        }
    }
}
