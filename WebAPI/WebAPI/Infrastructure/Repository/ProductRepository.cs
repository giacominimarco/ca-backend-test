using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ConnectionContext _connectionContext;
        public ProductRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public bool Delete(int id)
        {
            _connectionContext.Products.RemoveRange(new Product[id]);
            _connectionContext.SaveChanges();
            return true;
        }

        public Task<Product> Get(int id)
        {
            return _connectionContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Product>> GetProducts()
        {
            return _connectionContext.Products.ToListAsync();
        }

        public bool Save(Product product)
        {
            _connectionContext.Products.Add(product);
            _connectionContext.SaveChanges();
            return true;
        }

        public bool Update(Product product)
        {
            _connectionContext.Products.Update(product);
            _connectionContext.SaveChanges();
            return true;
        }
    }
}
