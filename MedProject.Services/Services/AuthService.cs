using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;
using MedProject.Services.Extensions;
using MedProject.Services.Helpers;
using MedProject.Services.Interfaces;
using MedProject.Services.Models;
using MedProject.Shared.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedProject.Services.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;

        public AuthService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(string login, string password)
        {
            var user = await this.userRepository.GetByLoginAsync(login);
            if (user == null)
            {
                return null;
            }

            if (PasswordHelper.VerifyHashedPassword(user.PasswordHash, password))
            {
                var issuer = ConfigAuthHelper.GetIssuer();
                var JWTSecret = ConfigAuthHelper.GetJWTSecret();

                return this.GetTokens(user, issuer, JWTSecret);
            }

            return null;
        }

        public async Task<AuthenticateResponse> RefreshTokenAsync(string token)
        {
            var issuer = ConfigAuthHelper.GetIssuer();
            var JWTSecret = ConfigAuthHelper.GetJWTSecret();

            try
            {
                var claimsPrincipal = JwtHelper.ValidateToken(token, issuer, JWTSecret);

                // TODO: add to the store refresh token and check used tokens

                var loginName = claimsPrincipal.GetClaim(ClaimTypes.NameIdentifier);
                var user = await this.userRepository.GetByLoginAsync(loginName);
                if (user == null)
                {
                    return null;
                }

                return this.GetTokens(user, issuer, JWTSecret);
            }
            catch (SecurityTokenException)
            {
                throw new MedException("Refresh token isn't valid!");
            }
        }

        private AuthenticateResponse GetTokens(MedUser user, string issuer, byte[] JWTSecret)
        {
            var tokenLifetime = ConfigAuthHelper.GetTokenLifetime();
            var refreshLifetime = ConfigAuthHelper.GetRefreshLifetime();

            var idToken = JwtHelper.GenerateIdToken(user, JWTSecret);
            var accessToken = JwtHelper.GenerateAccessToken(user, issuer, JWTSecret, tokenLifetime);
            var refreshToken = JwtHelper.GenerateRefreshToken(user, issuer, JWTSecret, refreshLifetime);

            return new AuthenticateResponse()
            {
                IdToken = idToken,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }
    }
}
