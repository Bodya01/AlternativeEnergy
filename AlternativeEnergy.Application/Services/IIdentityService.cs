using AlternativeEnergy.Infrastructure.Identity.Models;
using AlternativeEnergy.Infrastructure.Models.Dtos;

namespace AlternativeEnergy.Application.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(LoginModel model, CancellationToken cancellationToken = default);
        Task<AuthenticationResult> RegisterAsync(RegistrationModel model, CancellationToken cancellationToken = default);
        Task<AuthenticationResult> RefreshAsync(RefreshTokenDto model, CancellationToken cancellationToken = default);
    }
}
