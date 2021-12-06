using MedProject.BusinessLogic.Interfaces;
using MedProject.Web.Extensions;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    [Authorize]
    public class PharmacyController : ApiController
    {
        private readonly IPharmacyService pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }

        [Authorize(Roles = "Pharmacist, Patient")]
        public async Task<IHttpActionResult> Get()
        {
            var list = this.User.IsInRole("Pharmacist")
                ? await this.pharmacyService.GetListAsync()
                : await this.pharmacyService.GetAssignedAsync(this.User.GetNameId());
            return this.Ok(list);
        }
    }
}
