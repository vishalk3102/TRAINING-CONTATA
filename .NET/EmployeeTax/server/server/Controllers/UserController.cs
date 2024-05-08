using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using server.Model;
using server.Services;
using System.Web.Http.Cors;

namespace server.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class UserController : Controller
    {
        private readonly UserService _userService;


        public UserController(UserService userService)
        {
            _userService = userService;
        }



        //LOGIN USER 
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
<<<<<<< HEAD
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _userService.login(user);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(new { success = true, message = "Logout successful" });
        }

=======
            return await _userService.login(user);
        }

>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
    }
}
