using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spix.Api.Core;
using Spix.Application.Core;
using Spix.Application.Users.RegisterUser;

namespace Spix.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Authentication.Register)]
        [ProducesResponseType(typeof(ResultBase<CreateUserResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResultBase<CreateUserResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(command);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
