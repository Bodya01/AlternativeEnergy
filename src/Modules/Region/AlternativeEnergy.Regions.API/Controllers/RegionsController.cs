using AlternativeEnergy.CQRS;
using AlternativeEnergy.Regions.Application.Commands;
using AlternativeEnergy.Regions.Application.Dtos;
using AlternativeEnergy.Regions.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.Regions.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/regions")]
    public sealed class RegionsController : ControllerBase
    {
        private readonly ISender _sender;

        public RegionsController(ISender mediator)
            => _sender = mediator;

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken) =>
            Ok(await _sender.PublishAsync<GetAllRegions, IEnumerable<RegionDto>>(new GetAllRegions(), cancellationToken));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) =>
            Ok(await _sender.PublishAsync<GetRegion, RegionDto>(new GetRegion(id), cancellationToken));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegion command, CancellationToken cancellationToken) =>
            Ok(await _sender.PublishAsync<CreateRegion, Guid>(command, cancellationToken));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRegion command, CancellationToken cancellationToken)
        {
            await _sender.PublishAsync(command, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteRegion command, CancellationToken cancellationToken)
        {
            await _sender.PublishAsync(command, cancellationToken);
            return Ok();
        }

    }
}
