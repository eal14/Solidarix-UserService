using Solidarix.UserService.Domain.Entities;

namespace Solidarix.UserService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
