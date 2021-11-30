using System.Configuration;
using System.Text;

namespace MedProject.Services.Helpers
{
    public static class ConfigAuthHelper
    {
        public static byte[] GetJWTSecret()
        {
            var secret = ConfigurationManager.AppSettings["JWT_Secret"];
            return Encoding.ASCII.GetBytes(secret);
        }

        public static string GetIssuer()
        {
            return ConfigurationManager.AppSettings["issuer"];
        }

        public static int GetTokenLifetime()
        {
            return int.Parse(ConfigurationManager.AppSettings["tokenLifetime"]);
        }

        public static int GetRefreshLifetime()
        {
            return int.Parse(ConfigurationManager.AppSettings["refreshLifetime"]);
        }
    }
}
