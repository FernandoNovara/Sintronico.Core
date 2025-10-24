namespace Application.Interfaces
{
    public interface IBikeService
    {
        Task<PagedResult<BikeDto>> GetPagedAsync(int page, int pageSize, string? category);
    }
}
