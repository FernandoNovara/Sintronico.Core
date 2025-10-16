using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class BikeRepository : IBikeRepository
    {
        private readonly SintronicoDBContext _context;

        public BikeRepository(SintronicoDBContext context)
        {
            _context = context;
        }

        public Task AddAsync(Bike entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Bike>> GetAllAsync()
        {
            try
            {
                return await _context.Bikes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving bikes from database.", ex);
            }
        }

        public Task<List<Bike>> GetAllAsync(int page = 1, int pageSize = 10, string? category = null)
        {
            throw new NotImplementedException();
        }

        public Task<Bike?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Bike entity)
        {
            throw new NotImplementedException();
        }
    }
}
