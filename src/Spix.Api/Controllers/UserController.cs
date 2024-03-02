using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spix.Application.Interfaces;
using Spix.Application.Users.RegisterUser;

namespace Spix.Api.Controllers
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

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {
            await _userService.CreateUserAsync(command);
            return Ok();
        }
    }
}
