using Solidarix.UserService.Domain.Entities;

namespace Solidarix.UserService.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string GenerateRefreshToken(User user);
        bool ValidateToken(string token);
        string RefreshToken(string refreshToken, User user);
    }
}
