using Newtonsoft.Json;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Service
{
    public class ImportDataService : IImportDataService
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        public ImportDataService(IProductService productService, ICustomerService customerService)
        {
            _productService = productService;
            _customerService = customerService;
        }

        public async Task<BillingDTO> ImportFirstData()
        {
            try
            {
                List<object> billings = await GetBillings();
                object? objBilling = billings.FirstOrDefault();
                if (objBilling is null)
                    throw new Exception("Billing not found");

                BillingDTO billing = JsonConvert.DeserializeObject<BillingDTO>(objBilling.ToString());

                if (billing is null)
                    throw new Exception("Billing not found");
                if (billing.Customer is null)
                    throw new Exception("Customer not found");
                if (billing.Lines is null)
                    throw new Exception("Linnes not found");

                AddCustomer(billing.Customer);
                AddLinnes(billing.Lines);

                return billing;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        private bool AddLinnes(List<BillingLineDTO> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                BillingLineDTO billingLine = lines[i];
                Product product = new Product();
                product.Id = Guid.Parse(billingLine.ProductId);
                product.Name = billingLine.Description;
                _productService.Insert(product);
            }
            return true;
        }

        private bool AddCustomer(Customer customer)
        {
            return _customerService.Insert(customer);
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
            catch (HttpRequestException e)
            {
                throw e;
            }
        }
    }
}
