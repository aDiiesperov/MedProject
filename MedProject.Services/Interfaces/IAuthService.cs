using MedProject.Services.Models;
using System.Threading.Tasks;

namespace MedProject.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticateResponse> AuthenticateAsync(string login, string password);

        Task<AuthenticateResponse> RefreshTokenAsync(string token);
    }
}
