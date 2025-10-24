using Domain;
using Domain.Interfaces;
using Infrastructure.Excepctions;
using Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class BikeRepository : IBikeRepository
    {
        private readonly SintronicoDBContext _context;
        private readonly ILogService<LogService> _log;

        public BikeRepository(SintronicoDBContext context, ILogService<LogService> log)
        {
            _context = context;
            _log = log;
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
            _log.LogInfo("BikeRepository.GetAllAsync - init");
            try
            {
                var list = await _context.Bikes.AsNoTracking().ToListAsync();
                _log.LogInfo("BikeRepository.GetAllAsync - finish succesful");
                return list;
            }
            catch (Exception ex)
            {
                _log.LogError($"BikeRepository.GetAllAsync - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving bikes from database.", ex);
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
