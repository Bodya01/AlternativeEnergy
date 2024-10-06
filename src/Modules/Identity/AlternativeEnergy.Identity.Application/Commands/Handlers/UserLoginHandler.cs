using AlternativeEnergy.Identity.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AlternativeEnergy.Identity.Application.Commands.Handlers
{
    internal sealed class UserLoginHandler : IRequestHandler<LoginUser, AuthenticationResult>
    {
        private readonly IIdentityService _identityService;

        public UserLoginHandler(IIdentityService identityService, ILogger<UserLoginHandler> logger)
            => _identityService = identityService;

        public async Task<AuthenticationResult> Handle(LoginUser request, CancellationToken cancellationToken)
            => await _identityService.LoginAsync(request, cancellationToken);
    }
}
