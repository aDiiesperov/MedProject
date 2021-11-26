using MedProject.DataAccess.Interfaces;
using MedProject.Services.Helpers;
using MedProject.Services.Interfaces;
using MedProject.Services.Models;
using System.Configuration;
using System.Text;
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

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest loginModel)
        {
            var user = await this.userRepository.GetByLoginAsync(loginModel.LoginName);
            if (user == null)
            {
                return null;
            }

            if (PasswordHelper.VerifyHashedPassword(user.PasswordHash, loginModel.Password))
            {
                var issuer = ConfigurationManager.AppSettings["issuer"];
                var secret = ConfigurationManager.AppSettings["JWT_Secret"];
                var JWTSecret = Encoding.ASCII.GetBytes(secret);

                var idToken = JwtHelper.GenerateIdToken(user, JWTSecret);
                var accessToken = JwtHelper.GenerateAccessToken(issuer, JWTSecret);

                return new AuthenticateResponse()
                {
                    IdToken = idToken,
                    AccessToken = accessToken,
                };
            }

            return null;
        }
    }
}
