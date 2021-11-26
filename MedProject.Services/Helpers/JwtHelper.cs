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
            var claimsIdentity = JwtHelper.GetClaimsIdentity(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            return JwtHelper.GenerateJwtToken(tokenDescriptor);
        }

        public static string GenerateAccessToken(string issuer, byte[] JWTSecret)
        {
            var credentials = JwtHelper.GenerateCredentials(JWTSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = issuer,
                SigningCredentials = credentials
            };

            return JwtHelper.GenerateJwtToken(tokenDescriptor);
        }

        private static ClaimsIdentity GetClaimsIdentity(MedUser user)
        {
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(nameof(user.Id).FirstToLower(), user.Id.ToString()));
            permClaims.Add(new Claim(nameof(user.FirstName).FirstToLower(), user.FirstName));
            permClaims.Add(new Claim(nameof(user.LastName).FirstToLower(), user.LastName));
            permClaims.Add(new Claim(nameof(user.Roles).FirstToLower(), JsonSerializer.Serialize(user.Roles.Select(r => r.Name))));

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
