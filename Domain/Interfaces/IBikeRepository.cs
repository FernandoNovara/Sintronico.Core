using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IBikeRepository : IRepository<Bike>
    {
        Task<List<Bike>> GetAllAsync(int page = 1, int pageSize = 10, string? category = null);
        Task<bool> UpdateAsync(Bike entity);
        Task<bool> ChangeState(Guid BikeId, BikeState state);
    }
}
