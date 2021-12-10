using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Services.Interfaces;
using MedProject.Web.Extensions;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        [Route("request")]
        public async Task<IHttpActionResult> RequestMedications([FromBody] MedicationRequestDto model)
        {
            var userId = this.User.GetNameId();

            await this.orderService.QueryAsync(userId, model);
            return this.Ok();
        }

        [HttpPatch]
        [Authorize(Roles = "Patient")]
        [Route("cancel")]
        public async Task<IHttpActionResult> CancelMedications([FromBody] MedicationCancelDto model)
        {
            var userId = this.User.GetNameId();

            await this.orderService.CancelAsync(userId, model);
            return this.Ok();
        }

        [HttpPatch]
        [Authorize(Roles = "Pharmacist")]
        [Route("accept/{orderId}")]
        public async Task<IHttpActionResult> AcceptMedications([FromUri] int orderId)
        {
            await this.orderService.AcceptAsync(orderId);
            return this.Ok();
        }

        [HttpPatch]
        [Authorize(Roles = "Pharmacist")]
        [Route("cancel/{orderId}")]
        public async Task<IHttpActionResult> CancelMedications([FromUri] int orderId)
        {
            await this.orderService.CancelAsync(orderId);
            return this.Ok();
        }

        [HttpPatch]
        [Authorize(Roles = "Pharmacist")]
        [Route("notify/{orderId}")]
        public async Task<IHttpActionResult> NotifyPatient([FromUri] int orderId, [FromBody] double quantity)
        {
            await this.orderService.NotifyPatientAsync(orderId, quantity);
            return this.Ok();
        }
    }
}
