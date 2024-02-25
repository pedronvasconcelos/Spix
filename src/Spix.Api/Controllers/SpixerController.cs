using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spix.Application.Spixers.Create;
using Spix.Application.Spixers.Delete;
using Spix.Application.Spixers.Like;
using Spix.Application.Spixers.Unlike;

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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }       
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LikeSpixer([FromBody] LikeASpixerCommand command)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UnlikeSpixer([FromBody] UnlikeASpixerCommand command)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteSpixer([FromBody] Guid guid)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new DeleteSpixerCommand(Guid.NewGuid(), guid);    
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
