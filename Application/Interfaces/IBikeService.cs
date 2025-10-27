namespace Application.Interfaces
{
    public interface IBikeService
    {
        Task<PagedResult<BikeDto>> GetPagedAsync(int page, int pageSize, string? category);

        Task<BikeDto> GetBike(Guid BikeId);

        Task<bool> UpdateBikeInfo(Bike entity);

        Task<bool> ChangeStatus(Guid BikeId, BikeState state);
    }
}
