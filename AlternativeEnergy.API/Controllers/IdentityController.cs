using AlternativeEnergy.API.Controllers.Base;
using AlternativeEnergy.Application.Services;
using AlternativeEnergy.Infrastructure.Identity.Models;
using AlternativeEnergy.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/identity")]
    public sealed class IdentityController : AlternativeEnergyControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService) : base()
        {
            _identityService = identityService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken cancellationToken)
        {
            var r = await _identityService.LoginAsync(model, cancellationToken);
            return Ok(r);
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model, CancellationToken cancellationToken)
        {
            var r = await _identityService.RegisterAsync(model, cancellationToken);
            return Ok(r);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto model, CancellationToken cancellationToken)
        {
            var r = await _identityService.RefreshAsync(model, cancellationToken);
            return Ok(r);
        }
    }
}
