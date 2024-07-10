using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Get")]
        public Task<Product> Get([FromQuery] Guid id)
        {
            return _productService.Get(id);
        }

        [HttpDelete("Delete")]
        public bool Delete([FromQuery] Guid id)
        {
            return _productService.Delete(id);
        }

        [HttpGet("GetProducts")]
        public Task<List<Product>> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpPost("Insert")]
        public Task<bool> Insert([FromBody] Product product)
        {
            return _productService.Insert(product);
        }

        [HttpPut("Update")]
        public bool Update([FromBody] Product product)
        {
            return _productService.Update(product);
        }
    }
}