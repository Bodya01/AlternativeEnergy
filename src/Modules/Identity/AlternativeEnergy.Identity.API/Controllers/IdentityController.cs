using AlternativeEnergy.Identity.Application.Commands;
using MediatR;
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
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator/*, UserManager<AppUser> userManager*/) : base()
        {
            _mediator = mediator;
            //_userManager = userManager;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login([FromBody] LoginUser model, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(model, cancellationToken));

        [HttpPost("sign-up")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(model, cancellationToken));

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshAccessToken model, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(model, cancellationToken));

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
