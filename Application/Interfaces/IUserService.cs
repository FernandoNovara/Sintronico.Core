namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedResult<UserDto>> GetPagedAsync(int page, int pageSize, UserRole role);
    }
}
