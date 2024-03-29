﻿using MedProject.BusinessLogic.Models;
using MedProject.Services.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace MedProject.Services.Helpers
{
    internal static class JwtHelper
    {
        public static string GenerateIdToken(MedUser user, byte[] JWTSecret)
        {
            var credentials = JwtHelper.GenerateCredentials(JWTSecret);
            var claimsIdentity = user.GetClaimsForIdToken();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                SigningCredentials = credentials
            };

            return JwtHelper.GenerateJwtToken(tokenDescriptor);
        }

        public static string GenerateAccessToken(MedUser user, string issuer, byte[] JWTSecret, int lifetime)
        {
            var credentials = JwtHelper.GenerateCredentials(JWTSecret);
            var claimsIdentity = user.GetClaimsForAccessToken();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(lifetime),
                Issuer = issuer,
                Audience = issuer,
                SigningCredentials = credentials
            };

            return JwtHelper.GenerateJwtToken(tokenDescriptor);
        }

        public static string GenerateRefreshToken(MedUser user, string issuer, byte[] JWTSecret, int lifetime)
        {
            var credentials = JwtHelper.GenerateCredentials(JWTSecret);
            var claimsIdentity = user.GetClaimsForRefreshToken();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(lifetime),
                Issuer = issuer,
                Audience = issuer,
                SigningCredentials = credentials
            };

            return JwtHelper.GenerateJwtToken(tokenDescriptor);
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

        public static JwtSecurityToken DecodeJwt(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.ReadJwtToken(jwt);
        }

        public static bool TryValidateToken(string token, TokenValidationParameters validationParams, out JwtSecurityToken jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, validationParams, out var securityToken);
                jwtToken = (JwtSecurityToken)securityToken;
                return true;
            }
            catch
            {
                jwtToken = null;
                return false;
            }
        }

        public static TokenValidationParameters GetValidationParameters(string issuer, byte[] JWTSecret)
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(JWTSecret),
                ValidIssuer = issuer,
                ValidAudience = issuer,
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}
