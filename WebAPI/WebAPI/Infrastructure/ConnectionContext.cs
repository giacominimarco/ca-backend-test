using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
