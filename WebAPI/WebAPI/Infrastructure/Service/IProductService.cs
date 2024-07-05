using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Service
{
    public interface IProductService
    {
        public Task<Product> Get(int id);
        public Task<List<Product>> GetProducts();
        public bool Delete(int id);
        public bool Save(Product user);
        public bool Update(Product user);
    }
}