using MedProject.DataAccess.Models;
using MedProject.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MedProject.Services.Extensions
{
    internal static class ClaimsExtensions
    {
        public static ClaimsIdentity GetClaimsForIdToken(this MedUser user)
        {
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(nameof(user.FirstName).FirstToLower(), user.FirstName));
            permClaims.Add(new Claim(nameof(user.LastName).FirstToLower(), user.LastName));

            foreach (var role in user.Roles)
            {
                permClaims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return new ClaimsIdentity(permClaims);
        }

        public static ClaimsIdentity GetClaimsForAccessToken(this MedUser user)
        {
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(nameof(ClaimTypes.NameIdentifier), user.LoginName));

            foreach (var role in user.Roles)
            {
                permClaims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return new ClaimsIdentity(permClaims);
        }

        public static ClaimsIdentity GetClaimsForRefreshToken(this MedUser user)
        {
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.LoginName));

            return new ClaimsIdentity(permClaims);
        }

        public static string GetClaim(this ClaimsPrincipal claims, string type)
        {
            var value = claims.Claims.FirstOrDefault(claim => claim.Type == type)?.Value;
            if (value == null)
            {
                throw new ArgumentException($"ClaimsPrincipal missing claim: {type}");
            }

            return value;
        }
    }
}
