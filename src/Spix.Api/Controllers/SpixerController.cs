using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spix.Api.Core;
using Spix.Application.Core;
using Spix.Application.Spixers.Create;
using Spix.Application.Spixers.Delete;
using Spix.Application.Spixers.GetDetails;
using Spix.Application.Spixers.Like;
using Spix.Application.Spixers.Unlike;
using Spix.Domain.Core.Results;

namespace Spix.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class SpixerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpixerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Spixer.CreateSpixer)]
        [ProducesResponseType(typeof(Result<CreateSpixerCommand>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<CreateSpixerCommand>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSpixer([FromBody] CreateSpixerCommand command)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }       
            var response = await _mediator.Send(command);
            if(response.IsFailure)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost(ApiRoutes.Spixer.LikeSpixer)]
        [ProducesResponseType(typeof(Result<LikeASpixerCommand>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<LikeASpixerCommand>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LikeSpixer([FromBody] LikeASpixerCommand command)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(command);
            if(response.IsFailure)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost(ApiRoutes.Spixer.UnlikeSpixer)]
        [ProducesResponseType(typeof(Result<UnlikeASpixerCommand>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UnlikeASpixerCommand>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UnlikeSpixer([FromBody] UnlikeASpixerCommand command)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(command);
          
            if(response.IsFailure)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete(ApiRoutes.Spixer.DeleteSpixer)]
        [ProducesResponseType(typeof(Result<DeleteSpixerCommand>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<DeleteSpixerCommand>), StatusCodes.Status400BadRequest)]    

        public async Task<IActionResult> DeleteSpixer(Guid guid)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new DeleteSpixerCommand(Guid.NewGuid(), guid);    
            var response = await _mediator.Send(command);
  
            if(response.IsFailure)
            {
                return BadRequest(response);
            }   
            return Ok(response);
        }

        [HttpPost(ApiRoutes.Spixer.GetSpixerDetails)]
        [ProducesResponseType(typeof(Result<GetSpixerDetailResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<GetSpixerDetailResponse>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSpixerDetails([FromBody] GetSpixerDetailQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _mediator.Send(query);
            if(response is null)
            {
                return BadRequest(response);
            }       
            return Ok(response);
        }   
    }
}
