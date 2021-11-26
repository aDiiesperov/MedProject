using MedProject.BusinessLogic.Exceptions;
using MedProject.Services.Interfaces;
using MedProject.Services.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    [Authorize]
    public class AuthController : ApiController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Login([FromBody] AuthenticateRequest loginModel)
        {
            var res = await this.authService.AuthenticateAsync(loginModel);

            if (res == null)
                throw new MedException("Login or password is incorrect!", 401);

            return this.Ok(res);
        }
    }
}
