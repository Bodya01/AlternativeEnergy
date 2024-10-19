using AlternativeEnergy.CQRS;

namespace AlternativeEnergy.Identity.Application.Commands
{
    public sealed record RefreshAccessToken(string Token, string RefreshToken) : IRequest<AuthenticationResult>;
}
