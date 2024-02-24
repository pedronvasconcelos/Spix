using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spix.Application.Spixers.Create;

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
        public async Task<IActionResult> CreateSpixer([FromBody] CreateSpixerCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }               
    }
}
