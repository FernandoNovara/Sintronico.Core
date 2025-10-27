﻿namespace Infrastructure.Services
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


        public async Task<List<Bike>> GetAllAsync(int page = 1, int pageSize = 10, string? category = null)
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
                throw new InfrastructureException("Error retrieving bikes from database.", _log, ex);
            }
        }

        public async Task<Bike?> GetByIdAsync(Guid id)
        {
            _log.LogInfo("BikeRepository.GetByIdAsync - init");
            try
            {
                var bike = await _context.Bikes.FirstOrDefaultAsync(x => x.BikeId == id);
                _log.LogInfo("BikeRepository.GetByIdAsync - finish succesful");
                return bike;
            }
            catch (Exception ex)
            {
                _log.LogError($"BikeRepository.GetByIdAsync - error: {ex.Message}");
                throw new InfrastructureException("Error retrieving bike from database.", _log, ex);
            }
        }

        public async Task<bool> UpdateAsync(Bike entity)
        {
            _log.LogInfo("BikeRepository.UpdateAsync - init");
            try
            {
                var bike = await _context.Bikes.FirstOrDefaultAsync(x => x.BikeId == entity.BikeId);

                bike!.Category = entity.Category;
                bike.Color = entity.Color;
                bike.Observations = entity.Observations;
                bike.Price = entity.Price;

                var res = await _context.SaveChangesAsync() > 0;

                _log.LogInfo("BikeRepository.UpdateAsync - finish succesful");
                return res;
            }
            catch (Exception ex)
            {
                _log.LogError($"BikeRepository.UpdateAsync - error: {ex.Message}");
                throw new InfrastructureException($"An error occurred while updating information for bike {entity.BikeId}.", _log, ex);
            }
        }

        public async Task<bool> ChangeState(Guid BikeId, BikeState state)
        {
            _log.LogInfo("BikeRepository.ChangeState - init");
            try
            {
                Bike? bike = await _context.Bikes.FirstOrDefaultAsync(x => x.BikeId == BikeId);

                bike!.State = state;

                var res = await _context.SaveChangesAsync() > 0;

                _log.LogInfo("BikeRepository.ChangeState - finish succesful");
                return res;
            }
            catch (Exception ex)
            {
                _log.LogError($"BikeRepository.ChangeState - error: {ex.Message}");
                throw new InfrastructureException("An error occurred while updating the bike status in the database.", _log, ex);
            }
        }
    }
}
