using WebAPI.Domain.Model;

namespace WebAPI.Infrastructure.Service
{
    public interface IUserService
    {
        public User Get(int id);
        public List<User> GetUsers();
        public bool Delete(int id);
        public bool Save(User user);
        public bool Update(User user);
    }
}
