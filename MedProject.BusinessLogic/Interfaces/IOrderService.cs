using MedProject.BusinessLogic.Dtos;
using System.Threading.Tasks;

namespace MedProject.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task RequestAsync(int userId, MedicationRequestDto model);

        Task CancelAsync(int userId, MedicationCancelDto model);

        Task AcceptAsync(int orderId);

        Task CancelAsync(int orderId);

        Task NotifyPatientAsync(int orderId, double quantity);
    }
}
