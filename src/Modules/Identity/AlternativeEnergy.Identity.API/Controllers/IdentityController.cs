using AlternativeEnergy.CQRS;
using AlternativeEnergy.Identity.Application.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlternativeEnergy.Identity.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/identity")]
    public sealed class IdentityController : ControllerBase
    {
        //private readonly UserManager<AppUser> _userManager;
        private readonly ISender _sender;

        public IdentityController(ISender mediator/*, UserManager<AppUser> userManager*/) : base()
        {
            _sender = mediator;
            //_userManager = userManager;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login([FromBody] LoginUser model, CancellationToken cancellationToken) =>
            Ok(await _sender.PublishAsync<LoginUser, AuthenticationResult>(model, cancellationToken));

        [HttpPost("sign-up")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model, CancellationToken cancellationToken) =>
            Ok(await _sender.PublishAsync<RegistrationModel, AuthenticationResult>(model, cancellationToken));

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshAccessToken model, CancellationToken cancellationToken) =>
            Ok(await _sender.PublishAsync<RefreshAccessToken, AuthenticationResult>(model, cancellationToken));

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
