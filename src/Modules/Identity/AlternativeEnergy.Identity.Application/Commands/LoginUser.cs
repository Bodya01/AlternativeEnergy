using AlternativeEnergy.CQRS;

namespace AlternativeEnergy.Identity.Application.Commands
{
    public sealed record LoginUser(string Email, string Password) : IRequest<AuthenticationResult>;
}