using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public interface IProductRepository
    {
        public Product Get(int id);
        public List<Product> GetProducts();
        public bool Delete(int id);
        public bool Save(Product user);
        public bool Update(Product user);
    }
}
