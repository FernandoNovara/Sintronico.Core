namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserDto>> GetPagedAsync(int page, int pageSize, UserRole? role);

        Task<UserDto> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(User entity);

        Task<bool> UpdateAsync(User entity);

        Task<bool> DeleteAsync(Guid id);

        Task<UserDto> Login(string user, string password);

        Task<bool> ChangePassword(Guid UserId, string newPassword);
    }
}
