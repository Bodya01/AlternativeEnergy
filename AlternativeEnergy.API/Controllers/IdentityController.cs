using AlternativeEnergy.API.Controllers.Base;
using AlternativeEnergy.Identity.Application.Services;
using AlternativeEnergy.Identity.Infrastructure.Dtos;
using AlternativeEnergy.Identity.Infrastructure.Models;
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
        public async Task<IActionResult> Login([FromBody] LoginModel model, CancellationToken cancellationToken) =>
            Ok(await _identityService.LoginAsync(model, cancellationToken));

        [HttpPost("sign-up")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model, CancellationToken cancellationToken) =>
            Ok(await _identityService.RegisterAsync(model, cancellationToken));

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto model, CancellationToken cancellationToken) =>
            Ok(await _identityService.RefreshAsync(model, cancellationToken));
    }
}
