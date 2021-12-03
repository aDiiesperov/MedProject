using MedProject.BusinessLogic.Interfaces;
using MedProject.Web.Extensions;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    [Authorize]
    public class MedicationController : ApiController
    {
        private readonly IMedicationService medicationService;

        public MedicationController(IMedicationService medicationService)
        {
            this.medicationService = medicationService;
        }

        [Authorize(Roles = "Patient")]
        public async Task<IHttpActionResult> GetMedicationsToOrder()
        {
            var userId = this.User.GetNameId();

            var list = await this.medicationService.GetMedicationsToOrderAsync(userId);
            return this.Ok(list);
        }
    }
}
