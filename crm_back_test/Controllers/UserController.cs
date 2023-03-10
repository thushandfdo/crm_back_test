using crm_back_test.Models;
using crm_back_test.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crm_back_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User?>> getUser(int userId)
        {
            var user = await _userService.getUser(userId);

            if (user == null)
            {
                return NotFound("User does not exist");
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>?>> getUsers()
        {
            var users = await _userService.getUsers();

            if (users == null)
            {
                return NotFound("Users list is Empty..!");
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User?>> postUser(User newUser)
        {
            var user = await _userService.postUser(newUser);

            if (user == null)
            {
                return NotFound("User is already exist..!");
            }

            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<User?>> putUser(int userId, User newUser)
        {
            var user = await _userService.putUser(userId, newUser);

            if (user == null)
            {
                return NotFound("User is not found..!");
            }

            return Ok(user);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<User?>> deleteUser(int userId)
        {
            var user = await _userService.deleteUser(userId);

            if (user == null)
            {
                return NotFound("User is not found..!");
            }

            return Ok(user);
        }
    }
}
