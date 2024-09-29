using AlternativeEnergy.Identity.Application.Exceptions.RefreshToken;
using AlternativeEnergy.Identity.Application.Exceptions.User;
using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Domain.Repositories;
using AlternativeEnergy.Identity.Infrastructure.Dtos;
using AlternativeEnergy.Identity.Infrastructure.Models;
using AlternativeEnergy.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlternativeEnergy.Identity.Application.Services
{
    internal sealed class IdentityService : IIdentityService
    {
        private readonly ApplicationConfigs _configs;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public IdentityService(ApplicationConfigs configs, TokenValidationParameters tokenValidationParameters, UserManager<AppUser> userManager, IRefreshTokenRepository refreshTokenRepository)
        {
            _configs = configs;
            _tokenValidationParameters = tokenValidationParameters;
            _userManager = userManager;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<AuthenticationResult> LoginAsync(LoginModel model, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser is null) throw new UserNotFoundException();

            var isPasswordValid = await _userManager.CheckPasswordAsync(existingUser, model.Password);

            if (!isPasswordValid) throw new InvalidPasswordException();

            var authResult = await GenerateTokenAsync(existingUser, cancellationToken);

            return authResult;
        }

        public async Task<AuthenticationResult> RegisterAsync(RegistrationModel model, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser is not null) throw new UserAlreadyExistsException();

            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) throw new UserWasNotCreatedException();

            var authResult = await GenerateTokenAsync(user, cancellationToken);
            return authResult;
        }

        public async Task<AuthenticationResult> RefreshAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken = default)
        {
            var validatedToken = GetPrincipalFromToken(refreshTokenDto.Token);
            if (validatedToken is null) throw new RefreshTokenIsInvalidException();

            var expiryDateUnix = long.Parse(validatedToken.Claims
                .Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTime = DateTime.UnixEpoch
                .AddSeconds(expiryDateUnix)
                .Subtract(_configs.JwtSettings.LifeTime);

            if (expiryDateTime > DateTime.UtcNow)
                throw new RefreshTokenIsExpiredException();

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await _refreshTokenRepository.GetByIdAsync(refreshTokenDto.RefreshToken, cancellationToken);
            if (storedRefreshToken is null ||
                DateTime.UtcNow > storedRefreshToken.ExpiryDate ||
                storedRefreshToken.Invalidated ||
                storedRefreshToken.IsUsed ||
                storedRefreshToken.JwtId != jti)
            {
                throw new RefreshTokenIsInvalidException();
            }

            storedRefreshToken.IsUsed = true;
            await _refreshTokenRepository.UpdateAsync(storedRefreshToken, cancellationToken);
            await _refreshTokenRepository.SaveChangesAsync(cancellationToken);

            var userIdClaim = validatedToken.Claims.Single(c => c.Type == "Id").Value;
            var user = await _userManager.FindByIdAsync(userIdClaim);

            return await GenerateTokenAsync(user, cancellationToken);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                if (!HasValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }
                return principal;
            }
            catch
            {
                return null;
            }
        }

        private static bool HasValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return validatedToken is JwtSecurityToken jwtSecurityToken
                && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase);
        }

        private async Task<AuthenticationResult> GenerateTokenAsync(AppUser user, CancellationToken cancellationToken = default)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configs.JwtSettings.SecretKey);

            var tokenDescriptor = CreateTokenDescriptor(user, key);
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = await CreateRefreshTokenAsync(user, token.Id, cancellationToken);

            return new AuthenticationResult(token.Id, tokenHandler.WriteToken(token), tokenDescriptor.Expires, refreshToken.Token, user);
        }

        private SecurityTokenDescriptor CreateTokenDescriptor(AppUser user, byte[] key)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("Id", user.Id.ToString())
                ]),
                Expires = DateTime.UtcNow.Add(_configs.JwtSettings.LifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
        }

        private async Task<RefreshToken> CreateRefreshTokenAsync(AppUser user, string jwtId, CancellationToken cancellationToken = default)
        {
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                JwtId = jwtId,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6)
            };

            await _refreshTokenRepository.CreateAsync(refreshToken, cancellationToken);
            await _refreshTokenRepository.SaveChangesAsync(cancellationToken);

            return refreshToken;
        }
    }
}
