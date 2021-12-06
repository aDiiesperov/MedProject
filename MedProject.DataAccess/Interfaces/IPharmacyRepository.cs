using MedProject.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedProject.DataAccess.Interfaces
{
    public interface IPharmacyRepository : IRepository<Pharmacy>
    {
        Task<IList<Pharmacy>> GetAssignedAsync(int userId);
    }
}
