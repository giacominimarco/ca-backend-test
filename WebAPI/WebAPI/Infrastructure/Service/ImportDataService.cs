using Newtonsoft.Json;
using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Repository;

namespace WebAPI.Infrastructure.Service
{
    public class ImportDataService : IImportDataService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        public ImportDataService(IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<BillingDTO> ImportFirstData()
        {
            try
            {
                List<object> billings = await GetBillings();
                object? objBilling = billings.FirstOrDefault();
                if (objBilling is null)
                    throw new Exception("Billing not found");

                BillingDTO billing = JsonConvert.DeserializeObject<BillingDTO>(objBilling.ToString()); ;

                if (billing is null)
                    throw new Exception("Billing not found");
                if (billing.Customer is null)
                    throw new Exception("Customer not found");
                if (billing.Lines is null)
                    throw new Exception("Linnes not found");

                await HasCustomer(billing.Customer);
                await HasLinnes(billing.Lines);
                
                await AddCustomer(billing.Customer);
                await AddLinnes(billing.Lines);

                return billing;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        private Task AddLinnes(List<BillingLineDTO> lines)
        {
            throw new NotImplementedException();
        }

        private Task AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        private Task HasLinnes(List<BillingLineDTO> lines)
        {
            throw new Exception("Linnes not found");
        }

        private Task HasCustomer(Customer customer)
        {
            throw new Exception("Customer not found");
        }

        private static async Task<List<object>> GetBillings()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "text/html;charset=utf-8");
                client.BaseAddress = new Uri("https://65c3b12439055e7482c16bca.mockapi.io/");
                HttpResponseMessage response = await client.GetAsync("api/v1/billing");
                response.EnsureSuccessStatusCode();
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new HttpRequestException(response.ToString());
                return await response.Content.ReadFromJsonAsync<List<object>>();
            }
            catch(HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
