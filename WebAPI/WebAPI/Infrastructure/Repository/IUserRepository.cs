using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Repository
{
    public interface IUserRepository
    {
        public Task<User> Get(int id);
        public Task<List<User>> GetUsers();
        public bool Delete(int id);
        public bool Save(User user);
        public bool Update(User user);
    }
}
