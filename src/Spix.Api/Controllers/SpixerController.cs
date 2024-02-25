using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spix.Application.Spixers.Create;
using Spix.Application.Spixers.Like;

namespace Spix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpixerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpixerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]  
        public async Task<IActionResult> CreateSpixer([FromBody] CreateSpixerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LikeSpixer([FromBody] LikeASpixerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }   
    }
}
