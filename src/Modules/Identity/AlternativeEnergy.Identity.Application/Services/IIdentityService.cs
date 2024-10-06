using AlternativeEnergy.Identity.Application.Commands;

namespace AlternativeEnergy.Identity.Application.Services
{
    internal interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(LoginUser model, CancellationToken cancellationToken = default);
        Task<AuthenticationResult> RegisterAsync(RegistrationModel model, CancellationToken cancellationToken = default);
        Task<AuthenticationResult> RefreshAsync(RefreshAccessToken model, CancellationToken cancellationToken = default);
    }
}
