using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Repository;

namespace WebAPI.Infrastructure.Service
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public BillingService(IBillingRepository billingRepository, IProductService productService, ICustomerService customerService)
        {
            _billingRepository = billingRepository;
            _productService = productService;
            _customerService = customerService;
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

        public async Task<bool> Insert(Billing billing)
        {

            try
            {
                await HasCustomer(billing.Customer);
                await HasLinnes(billing.Lines);
                return await _billingRepository.Insert(billing);
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        private async Task HasLinnes(List<BillingLine> lines)
        {
            List<string> linesNotFound = new List<string>();
            for (int i = 0; i < lines.Count; i++)
            {
                BillingLine billingLine = lines[i];
                Product answerProduct = await _productService.Get(billingLine.Product.Id);
                if (answerProduct is null)
                    linesNotFound.Add(billingLine.Description);
            }
            if (linesNotFound.Count > 0)
                throw new DataException($"Linnes not found: {string.Join(", ", linesNotFound)}");
        }

        private async Task HasCustomer(Customer customer)
        {
            Customer answerCustomer = await _customerService.Get(customer.Id);
            if (answerCustomer is null)
                throw new DataException($"Customer '{customer.Name}' not found");
        }

        public bool Update(Billing billing)
        {
            return _billingRepository.Update(billing);
        }
    }
}
