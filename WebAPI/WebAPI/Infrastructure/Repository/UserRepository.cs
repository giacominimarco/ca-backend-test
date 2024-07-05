using Microsoft.EntityFrameworkCore;
using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _connectionContext;
        public UserRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public bool Delete(int id)
        {
            _connectionContext.Users.RemoveRange(new User[id]);
            _connectionContext.SaveChanges();
            return true;
        }

        public Task<User> Get(int id)
        {
            return _connectionContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<User>> GetUsers()
        {
            return _connectionContext.Users.ToListAsync();
        }

        public bool Save(User user)
        {
            _connectionContext.Users.Add(user);
            _connectionContext.SaveChanges();
            return true;
        }

        public bool Update(User user)
        {
            _connectionContext.Users.Update(user);
            _connectionContext.SaveChanges();
            return true;
        }
    }
}
