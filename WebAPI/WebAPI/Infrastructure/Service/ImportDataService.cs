using Newtonsoft.Json;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Service
{
    public class ImportDataService : IImportDataService
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IBillingService _billingService;
        public ImportDataService(IProductService productService, ICustomerService customerService, IBillingService billingService)
        {
            _productService = productService;
            _customerService = customerService;
            _billingService = billingService;
        }

        public async Task<BillingDTO> ImportFirstData()
        {
            try
            {
                List<object> billings = await GetBillings();
                object? objBilling = billings.FirstOrDefault();
                if (objBilling is null)
                    throw new DataException("Billing not found");

                BillingDTO billing = JsonConvert.DeserializeObject<BillingDTO>(objBilling.ToString());

                if (billing is null)
                    throw new DataException("Billing not found");
                if (billing.Customer is null)
                    throw new DataException("Customer not found");
                if (billing.Lines is null)
                    throw new DataException("Linnes not found");

                await AddCustomer(billing.Customer);
                await AddLinnes(billing.Lines);

                return billing;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        public async Task<bool> ImportData()
        {
            try
            {
                List<object> billingsObj = await GetBillings();
                List<BillingDTO> billings = CreateBillings(billingsObj);
                if (billings is null)
                    throw new DataException("Billings not found");

                for (int i = 0; i < billings.Count; i++)
                {
                    BillingDTO billingDTO = billings[i];
                    Billing billing = CreateBilling(billingDTO);
                    await _billingService.Insert(billing);
                }
                return true;
            }
            catch (DataException e)
            {
                throw e;
            }
        }

        private List<BillingDTO> CreateBillings(List<object> billingsObj)
        {
            List<BillingDTO> billings = new List<BillingDTO>();

            for (int i = 0; i < billingsObj.Count; i++)
            {
                object billingObj = billingsObj[i];
                BillingDTO billingDTO = JsonConvert.DeserializeObject<BillingDTO>(billingObj.ToString());
                billings.Add(billingDTO);
            }

            return billings;
        }

        private Billing CreateBilling(BillingDTO billingDTO)
        {
            Billing billing = new Billing();
            billing.Id = Guid.NewGuid();
            billing.InvoiceNumber = billingDTO.InvoiceNumber;
            billing.Customer = billingDTO.Customer;
            billing.Date = billingDTO.Date;
            billing.DueDate = billingDTO.DueDate;
            billing.TotalAmount = billingDTO.TotalAmount;
            billing.Currency = billingDTO.Currency;
            List<BillingLine> billingLines = CreateBillingLines(billingDTO.Lines);
            billing.Lines = billingLines;
            return billing;
        }

        private List<BillingLine> CreateBillingLines(List<BillingLineDTO> lines)
        {
            List<BillingLine> billingLines = new List<BillingLine>();
            for (int i = 0; i < lines.Count; i++)
            {
                BillingLineDTO billingLineDTO = lines[i];
                BillingLine billingLine = new BillingLine();
                billingLine.Id = Guid.NewGuid();
                billingLine.Description = billingLineDTO.Description;
                billingLine.Quantity = billingLineDTO.Quantity;
                billingLine.UnitPrice = billingLineDTO.UnitPrice;
                billingLine.Subtotal = billingLineDTO.Subtotal;
                billingLine.Product.Id = Guid.Parse(billingLineDTO.ProductId);
                billingLine.Product.Name = billingLineDTO.Description;
                billingLines.Add(billingLine);
            }
            return billingLines;
        }

        private async Task<bool> AddLinnes(List<BillingLineDTO> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                BillingLineDTO billingLine = lines[i];
                Product product = new Product();
                product.Id = Guid.Parse(billingLine.ProductId);
                product.Name = billingLine.Description;
                await _productService.Insert(product);
            }
            return await Task.FromResult(true);
        }

        private Task<bool> AddCustomer(Customer customer)
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
