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
        public async Task<ActionResult<List<User>?>> postUser(User newUser)
        {
            var users = await _userService.postUser(newUser);

            if (users == null)
            {
                return NotFound("User is already exist..!");
            }

            return Ok(users);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<List<User>?>> putUser(int userId, User newUser)
        {
            var users = await _userService.putUser(userId, newUser);

            if (users == null)
            {
                return NotFound("User is not found..!");
            }

            return Ok(users);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<List<User>?>> deleteUser(int userId)
        {
            var users = await _userService.deleteUser(userId);

            if (users == null)
            {
                return NotFound("User is not found..!");
            }

            return Ok(users);
        }
    }
}
