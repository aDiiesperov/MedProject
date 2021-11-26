using System;
using System.Security.Cryptography;

namespace MedProject.Services.Helpers
{
    internal static class PasswordHelper
    {
        public static bool VerifyHashedPassword(string passwordHash, string password)
        {
            var hash = Convert.FromBase64String(passwordHash);

            if (string.IsNullOrEmpty(passwordHash) || string.IsNullOrEmpty(password) ||
                hash.Length != 0x31 || hash[0] != 0)
            {
                return false;
            }

            byte[] salt = new byte[0x10];
            Buffer.BlockCopy(hash, 1, salt, 0, 0x10);
            byte[] pass = new byte[0x20];
            Buffer.BlockCopy(hash, 0x11, pass, 0, 0x20);

            byte[] comparePass;

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, salt, 0x3e8))
            {
                comparePass = bytes.GetBytes(0x20);
                
            }

            return Convert.ToBase64String(pass) == Convert.ToBase64String(comparePass);
        }

        public static byte[] HashPassword(string password)
        {
            byte[] salt;
            byte[] hashPassword;

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                hashPassword = bytes.GetBytes(0x20);
            }

            byte[] hash = new byte[0x31];
            Buffer.BlockCopy(salt, 0, hash, 1, 0x10);
            Buffer.BlockCopy(hashPassword, 0, hash, 0x11, 0x20);
            return hash;
        }
    }
}
