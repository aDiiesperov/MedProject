using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;
using MedProject.Services.Extensions;
using MedProject.Services.Helpers;
using MedProject.Services.Interfaces;
using MedProject.Services.Models;
using MedProject.Shared.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace MedProject.Services.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;

        private readonly AuthCacheManager authCache;

        public AuthService(IUserRepository userRepository, AuthCacheManager authCache)
        {
            this.userRepository = userRepository;
            this.authCache = authCache;
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

        /// <exception cref="MedException"></exception>
        public async Task<AuthenticateResponse> RefreshTokenAsync(string token)
        {
            var issuer = ConfigAuthHelper.GetIssuer();
            var JWTSecret = ConfigAuthHelper.GetJWTSecret();
            var validationParams = JwtHelper.GetValidationParameters(issuer, JWTSecret);

            if (JwtHelper.TryValidateToken(token, validationParams, out var jwtToken))
            {
                if (this.authCache.Contains(token))
                {
                    throw new MedException("Previously consumed");
                }

                if (!this.authCache.TryAdd(token, jwtToken.ValidTo))
                {
                    throw new MedException("Failed to refresh!");
                }

                var loginName = jwtToken.GetClaim(JwtRegisteredClaimNames.NameId);
                var user = await this.userRepository.GetByLoginAsync(loginName);
                if (user == null)
                {
                    throw new MedException("Failed to refresh!"); ;
                }

                return this.GetTokens(user, issuer, JWTSecret);
            }
            else
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
