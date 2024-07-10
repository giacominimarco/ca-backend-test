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

        public bool Delete(Guid id)
        {
            return _productRepository.Delete(id);
        }

        public Task<Product> Get(Guid id)
        {
            return _productRepository.Get(id);
        }

        public Task<List<Product>> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public async Task<bool> Insert(Product product)
        {
            Product answerProduct = await _productRepository.Get(product.Id);
            if (answerProduct is null)
                return await _productRepository.Insert(product);
            return true;
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }
    }
}
