using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public interface IProductRepository
    {
        public Task<Product> Get(int id);
        public Task<List<Product>> GetProducts();
        public bool Delete(int id);
        public bool Insert(Product product);
        public bool Update(Product product);
    }
}
