using MedProject.Services.Interfaces;
using MedProject.Services.Models;
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

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody] AuthenticateRequest request)
        {
            var res = await this.authService.AuthenticateAsync(request);

            if (res == null)
                throw new MedException("Login or password is incorrect!");

            return this.Ok(res);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("refresh-token")]
        public async Task<IHttpActionResult> RefreshToken([QueryString] string token)
        {
            var res = await this.authService.RefreshTokenAsync(token);
            return this.Ok(res);
        }
    }
}
