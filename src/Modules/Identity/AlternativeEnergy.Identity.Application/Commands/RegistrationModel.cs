using AlternativeEnergy.CQRS;

namespace AlternativeEnergy.Identity.Application.Commands
{
    public sealed record RegistrationModel(string Email, string UserName, string Password, Guid RegionId) : IRequest<AuthenticationResult>;
}
