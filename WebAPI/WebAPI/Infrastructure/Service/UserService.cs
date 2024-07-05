using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Repository;

namespace WebAPI.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public Task<User> Get(int id)
        {
            return _userRepository.Get(id);
        }

        public Task<List<User>> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public bool Save(User user)
        {
            return _userRepository.Save(user);
        }

        public bool Update(User user)
        {
            return _userRepository.Update(user);
        }
    }
}
