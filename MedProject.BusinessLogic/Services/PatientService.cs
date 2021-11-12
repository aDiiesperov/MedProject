using MedProject.BusinessLogic.Dtos;
using MedProject.BusinessLogic.Interfaces;
using MedProject.BusinessLogic.Mappers;
using MedProject.DataAccess.Interfaces;
using MedProject.DataAccess.Models;

namespace MedProject.BusinessLogic.Services
{
    internal class PatientService : CrudService<PatientDto, Patient, IPatientRepository>, IPatientService
    {
        public PatientService(IPatientRepository repository) : base(repository)
        {
        }

        protected override PatientDto MapToDto(Patient model)
        {
            return model.MapToDto();
        }
    }
}
