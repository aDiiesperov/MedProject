using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;

namespace MedProject.DataAccess.Repositories
{
    internal class PharmacyRepository : Repository<Pharmacy>, IPharmacyRepository
    {
        protected override string nameGetProc { get; set; } = "GetAllPharmacies";
    }
}
