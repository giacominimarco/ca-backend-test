using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("Get")]
        public Task<Customer> Get([FromQuery] Guid id)
        {
            return _customerService.Get(id);
        }

        [HttpDelete("Delete")]
        public bool Delete([FromQuery] Guid id)
        {
            return _customerService.Delete(id);
        }

        [HttpGet("GetCustomers")]
        public Task<List<Customer>> Customers()
        {
            return _customerService.Customers();
        }

        [HttpPost("Insert")]
        public bool Insert(Customer customer)
        {
            return _customerService.Insert(customer);
        }

        [HttpPut("Update")]
        public bool Update(Customer customer)
        {
            return _customerService.Update(customer);
        }
    }
}