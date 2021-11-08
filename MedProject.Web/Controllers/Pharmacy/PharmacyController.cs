using MedProject.DataAccess.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace MedProject.Web.Controllers.Pharmacy
{
    public class PharmacyController : ApiController
    {
        private readonly IPharmacyRepository pharmacyRepository;

        public PharmacyController(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public async Task<IHttpActionResult> Get()
        {
            var list = await this.pharmacyRepository.GetAllAsync();
            var listRes = list.Select(p => p.MapToPharmacyRes());
            return this.Ok(listRes);
        }
    }
}
