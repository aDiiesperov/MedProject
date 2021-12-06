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
        public async Task<IHttpActionResult> RequestMedications([FromBody] MedicationRequestDto request)
        {
            var userId = this.User.GetNameId();

            await this.medicationService.RequestMedicationsAsync(userId, request);
            return this.Ok();
        }
    }
}
