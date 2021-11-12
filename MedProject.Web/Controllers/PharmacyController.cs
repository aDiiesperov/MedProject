using MedProject.BusinessLogic.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    public class PharmacyController : ApiController
    {
        private readonly IPharmacyService pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }

        public async Task<IHttpActionResult> Get()
        {
            var list = await this.pharmacyService.GetListAsync();
            return this.Ok(list);
        }
    }
}
