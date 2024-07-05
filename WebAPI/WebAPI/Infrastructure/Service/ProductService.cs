using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Repository;

namespace WebAPI.Infrastructure.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public Task<Product> Get(int id)
        {
            return _productRepository.Get(id);
        }

        public Task<List<Product>> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public bool Save(Product product)
        {
            return _productRepository.Save(product);
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
