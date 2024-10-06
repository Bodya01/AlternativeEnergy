using AlternativeEnergy.Regions.Application.Commands;
using AlternativeEnergy.Regions.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.Regions.API.Controllers
{
    [ApiController]
    [Route("api/regions")]
    public sealed class RegionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetAllRegions(), cancellationToken));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetRegion(id), cancellationToken));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegion command, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(command, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRegion command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteRegion command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return Ok();
        }

    }
}
