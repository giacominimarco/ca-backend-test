using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportDataController : ControllerBase
    {
        private readonly IImportDataService _apiService;

        public ImportDataController(IImportDataService apiService)
        {
            _apiService = apiService;
        }

        [HttpPost("ImportFirstData")]
        public Task<BillingDTO> ImportFirstData()
        {
            return _apiService.ImportFirstData();
        }
    }
}