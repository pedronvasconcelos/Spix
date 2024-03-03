using MediatR;
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
        private readonly IMediator _mediator;   

        public UserController(IMediator mediator)
        {
             _mediator = mediator;
        }

        [HttpPost]
        [Route(template: "[action]")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response =  await _mediator.Send(command);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
