using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public interface IProductRepository
    {
        public Task<Product> Get(Guid id);
        public Task<List<Product>> GetProducts();
        public bool Delete(Guid id);
        public Task<bool> Insert(Product product);
        public bool Update(Product product);
    }
}
