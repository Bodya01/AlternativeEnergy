using AlternativeEnergy.Identity.Infrastructure.Dtos;
using AlternativeEnergy.Identity.Infrastructure.Models;

namespace AlternativeEnergy.Identity.Application.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(LoginModel model, CancellationToken cancellationToken = default);
        Task<AuthenticationResult> RegisterAsync(RegistrationModel model, CancellationToken cancellationToken = default);
        Task<AuthenticationResult> RefreshAsync(RefreshTokenDto model, CancellationToken cancellationToken = default);
    }
}
