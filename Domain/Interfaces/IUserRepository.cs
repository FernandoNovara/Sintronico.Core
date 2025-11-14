using Domain.Entities;
using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetAllAsync(int page, int pageSize, UserRole? role);

        Task<bool> UpdateAsync(User entity);

        Task<User?> GetByCredentialsAsync(string email, string password);

        Task<bool> ChangePassword(Guid UserId, string newPassword);
    }
}
