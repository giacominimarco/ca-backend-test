using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Model;
using WebAPI.Infrastructure.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.Get(id);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _userService.Delete(id);
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }

        [HttpPost]
        public bool Save(User user)
        {
            return _userService.Save(user);
        }

        [HttpPut]
        public bool Update(User user)
        {
            return _userService.Update(user);
        }
    }
}