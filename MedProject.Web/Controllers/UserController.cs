using MedProject.BusinessLogic.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    // TODO: Test controller. Just for testing ado system
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IHttpActionResult> Get()
        {
            var list = await this.userService.GetListAsync();
            return this.Ok(list);
        }
    }
}
