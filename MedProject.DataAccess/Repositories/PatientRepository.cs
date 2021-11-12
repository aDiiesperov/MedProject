using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;

namespace MedProject.DataAccess.Repositories
{
    internal class PatientRepository : Repository<Patient>, IPatientRepository
    {
        protected override string nameGetProc => "GetAllPatients";
    }
}
