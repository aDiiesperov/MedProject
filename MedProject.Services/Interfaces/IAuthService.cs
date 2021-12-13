using MedProject.Services.Models;
using System.Threading.Tasks;

namespace MedProject.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);

        Task<AuthenticateResponse> RefreshTokenAsync(string token);
    }
}
