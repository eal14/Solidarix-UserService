using Microsoft.IdentityModel.Tokens;
using Solidarix.UserService.Application.Interfaces;
using Solidarix.UserService.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Solidarix.UserService.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _jwtSecret;

        public TokenService(string jwtSecret)
        {
            _jwtSecret = jwtSecret;
        }

        public string GenerateRefreshToken(User user)
        {
            // TODO: implementar un refresh token más robusto
            return Guid.NewGuid().ToString();
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSecret);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true
                }, out _);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string RefreshToken(string refreshToken, User user)
        {
            // Validar que el refresh token no esté vacío
            if (string.IsNullOrWhiteSpace(refreshToken))
                throw new DomainException("Error_InvalidToken");

            // Aquí podrías validar contra Redis o BD
            // Ejemplo simple: si el refresh token coincide con el guardado
            // (esto depende de cómo lo implementes en tu proyecto)

            // Generar nuevo access token
            return GenerateToken(user);
        }
    }
}
