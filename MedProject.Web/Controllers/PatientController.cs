﻿using MedProject.BusinessLogic.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers
{
    [Authorize]
    public class PatientController : ApiController
    {
        private readonly IUserService patientService;

        public PatientController(IUserService patientService)
        {
            this.patientService = patientService;
        }

        [Authorize(Roles = "Pharmacist")]
        public async Task<IHttpActionResult> Get()
        {
            var list = await this.patientService.GetPatientListAsync();
            return this.Ok(list);
        }
    }
}
