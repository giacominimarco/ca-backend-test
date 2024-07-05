using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet("Get")]
        public Task<Billing> Get([FromQuery] Guid id)
        {
            return _billingService.Get(id);
        }

        [HttpDelete("Delete")]
        public bool Delete([FromQuery] Guid id)
        {
            return _billingService.Delete(id);
        }

        [HttpGet("GetBillings")]
        public Task<List<Billing>> GetBillings()
        {
            return _billingService.GetBillings();
        }

        [HttpPost("Insert")]
        public bool Insert([FromBody] Billing billing)
        {
            return _billingService.Insert(billing);
        }

        [HttpPut("Update")]
        public bool Update([FromBody] Billing billing)
        {
            return _billingService.Update(billing);
        }
    }
}