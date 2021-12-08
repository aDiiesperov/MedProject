using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Interfaces;
using MedProject.Web.Extensions;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/medication")]
    public class MedicationController : ApiController
    {
        private readonly IMedicationService medicationService;

        public MedicationController(IMedicationService medicationService)
        {
            this.medicationService = medicationService;
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        [Route("medications-to-order")]
        public async Task<IHttpActionResult> GetMedicationsToOrder()
        {
            var userId = this.User.GetNameId();

            var list = await this.medicationService.GetMedicationsToOrderAsync(userId);
            return this.Ok(list);
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        [Route("request")]
        public async Task<IHttpActionResult> RequestMedications([FromBody] MedicationRequestDto model)
        {
            var userId = this.User.GetNameId();

            await this.medicationService.RequestMedicationsAsync(userId, model);
            return this.Ok();
        }

        [HttpPatch]
        [Authorize(Roles = "Patient")]
        [Route("cancel")]
        public async Task<IHttpActionResult> CancelMedications([FromBody] MedicationCancelDto model)
        {
            var userId = this.User.GetNameId();

            await this.medicationService.CancelMedicationsAsync(userId, model);
            return this.Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Pharmacist")]
        [Route("medications-info")]
        public async Task<IHttpActionResult> GetMedicationsInfo()
        {
            var list = await this.medicationService.GetMedicationsInfoAsync();
            return this.Ok(list);
        }
    }
}
