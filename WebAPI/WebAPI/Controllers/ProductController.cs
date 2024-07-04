using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.Get(id);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _productService.Delete(id);
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpPost]
        public bool Save(Product product)
        {
            return _productService.Save(product);
        }

        [HttpPut]
        public bool Update(Product product)
        {
            return _productService.Update(product);
        }
    }
}