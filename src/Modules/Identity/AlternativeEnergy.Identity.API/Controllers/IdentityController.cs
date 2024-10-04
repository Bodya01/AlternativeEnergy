using AlternativeEnergy.Identity.Application.Services;
using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Infrastructure.Dtos;
using AlternativeEnergy.Identity.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.Identity.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/identity")]
    public sealed class IdentityController : ControllerBase
    {
        //private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService/*, UserManager<AppUser> userManager*/) : base()
        {
            _identityService = identityService;
            //_userManager = userManager;
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

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new AppUser
        //    {
        //        UserName = model.Email,
        //        Email = model.Email,
        //        RegionId = Guid.NewGuid()
        //    };

        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return Ok("User registered successfully.");
        //    }

        //    return BadRequest(result.Errors);
        //}
    }
}
