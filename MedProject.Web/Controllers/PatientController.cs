using MedProject.BusinessLogic.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    public class PatientController : ApiController
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        public async Task<IHttpActionResult> Get()
        {
            var list = await this.patientService.GetListAsync();
            return this.Ok(list);
        }
    }
}
