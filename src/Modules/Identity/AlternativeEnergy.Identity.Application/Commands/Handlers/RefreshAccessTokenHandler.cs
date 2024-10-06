using AlternativeEnergy.Identity.Application.Services;
using MediatR;

namespace AlternativeEnergy.Identity.Application.Commands.Handlers
{
    internal sealed class RefreshAccessTokenHandler : IRequestHandler<RefreshAccessToken, AuthenticationResult>
    {
        private readonly IIdentityService _identityService;

        public RefreshAccessTokenHandler(IIdentityService identityService)
            => _identityService = identityService;

        public Task<AuthenticationResult> Handle(RefreshAccessToken request, CancellationToken cancellationToken)
            => _identityService.RefreshAsync(request, cancellationToken);
    }
}
