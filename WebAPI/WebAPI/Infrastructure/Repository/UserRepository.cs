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

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
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
