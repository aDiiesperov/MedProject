using MedProject.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace MedProject.Services.Helpers
{
    internal static class JwtHelper
    {
        public static string GenerateIdToken(MedUser user, byte[] JWTSecret)
        {
            var credentials = JwtHelper.GenerateCredentials(JWTSecret);
            var claimsIdentity = JwtHelper.GetClaimsForIdToken(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            return JwtHelper.GenerateJwtToken(tokenDescriptor);
        }

        private static ClaimsIdentity GetClaimsForIdToken(MedUser user)
        {
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(nameof(user.Id).FirstToLower(), user.Id.ToString()));
            permClaims.Add(new Claim(nameof(user.FirstName).FirstToLower(), user.FirstName));
            permClaims.Add(new Claim(nameof(user.LastName).FirstToLower(), user.LastName));

            foreach (var role in user.Roles)
            {
                permClaims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return new ClaimsIdentity(permClaims);
        }

        public static string GenerateAccessToken(MedUser user, string issuer, byte[] JWTSecret)
        {
            var credentials = JwtHelper.GenerateCredentials(JWTSecret);
            var claimsIdentity = JwtHelper.GetClaimsForAccessToken(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = issuer,
                SigningCredentials = credentials
            };

            return JwtHelper.GenerateJwtToken(tokenDescriptor);
        }

        private static ClaimsIdentity GetClaimsForAccessToken(MedUser user)
        {
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(nameof(user.Id), user.Id.ToString()));

            foreach(var role in user.Roles)
            {
                permClaims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return new ClaimsIdentity(permClaims);
        }

        private static SigningCredentials GenerateCredentials(byte[] JWTSecret)
        {
            var securityKey = new SymmetricSecurityKey(JWTSecret);
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }

        public static string GenerateJwtToken(SecurityTokenDescriptor tokenDescriptor)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
    }
}
