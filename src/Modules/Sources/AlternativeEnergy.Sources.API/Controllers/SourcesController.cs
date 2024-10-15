using AlternativeEnergy.Sources.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.Sources.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/sources")]
    public class SourcesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SourcesController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("get/{userId:guid}")]
        public IActionResult Get(Guid userId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSource command, CancellationToken cancellationToken)
            => Ok(await _mediator.Send(command, cancellationToken));
    }
}
