using MedProject.Services.Extensions;
using System.Security.Claims;
using System.Security.Principal;

namespace MedProject.Web.Extensions
{
    public static class UserExtensions
    {
        public static int GetNameId(this IPrincipal principal)
        {
            var claimsPrincipal = principal as ClaimsPrincipal;
            var nameId = claimsPrincipal.Claims.GetClaim(ClaimTypes.NameIdentifier);
            return int.Parse(nameId);
        }
    }
}