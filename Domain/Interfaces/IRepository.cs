namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(Guid id);

        Task<bool> AddAsync(T entity);

        Task<bool> DeleteAsync(Guid id);
    }
}
