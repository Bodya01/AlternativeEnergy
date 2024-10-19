using AlternativeEnergy.CQRS;
using AlternativeEnergy.Sources.Application.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.Sources.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/sources")]
    public class SourcesController : ControllerBase
    {
        private readonly ISender _sender;

        public SourcesController(ISender mediator)
            => _sender = mediator;

        [HttpGet("get/{userId:guid}")]
        public IActionResult Get(Guid userId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSource command, CancellationToken cancellationToken)
            => Ok(await _sender.PublishAsync<CreateSource, Guid>(command, cancellationToken));
    }
}
