using MedProject.Services.Interfaces;
using MedProject.Shared.Exceptions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;

namespace MedProject.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IHttpActionResult> Login([QueryString] string login, [QueryString] string password)
        {
            var res = await this.authService.AuthenticateAsync(login, password);

            if (res == null)
                throw new MedException("Login or password is incorrect!");

            return this.Ok(res);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("refresh-token")]
        public async Task<IHttpActionResult> RefreshToken([QueryString] string token)
        {
            var res = await this.authService.RefreshTokenAsync(token);

            if (res == null)
                throw new MedException("Failed to refresh!");

            return this.Ok(res);
        }
    }
}
