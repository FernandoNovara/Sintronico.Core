namespace Domain.Interfaces
{
    public interface IBikeRepository : IRepository<Bike>
    {
        Task<List<Bike>> GetAllAsync(int page = 1, int pageSize = 10, string? category = null);
    }
}
