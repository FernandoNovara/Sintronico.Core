namespace Application.Services
{
    public class BikeService : IBikeService
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task<PagedResult<BikeDto>> GetPagedAsync(int page, int pageSize, string? category)
        {
            if (page <= 0 || pageSize <= 0)
                throw new ApplicationException("Invalid parameters.");

            var bikes = await _bikeRepository.GetAllAsync(page, pageSize, category);

            if (!string.IsNullOrWhiteSpace(category))
                bikes = bikes.Where(b => b.Category == category).ToList();

            var total = bikes.Count;
            var items = bikes.Skip((page - 1) * pageSize).Take(pageSize).Select(BikeMapper.ToDto).ToList();

            return new PagedResult<BikeDto>
            {
                page = page,
                pageSize = pageSize,
                total = total,
                items = items
            };
        }

        public async Task<BikeDto> GetBike(Guid BikeId)
        {
            if (BikeId == Guid.Empty)
                throw new ApplicationException("Invalid BikeId.");

            var bike = await _bikeRepository.GetByIdAsync(BikeId);

            if (bike == null)
                throw new ApplicationException("Bike not found.");

            return BikeMapper.ToDto(bike);
        }

        public async Task<bool> UpdateBikeInfo(Bike entity)
        {
            if (entity.BikeId == Guid.Empty)
            {
                throw new ApplicationException("Invalid BikeId.");
            }

            entity.LastUpdatedAt = DateTime.UtcNow;

            bool res = await _bikeRepository.UpdateAsync(entity);

            return res;
        }

        public Task<bool> ChangeStatus(Guid BikeId, BikeState state)
        {
            if (BikeId == Guid.Empty)
            {
                throw new ApplicationException("Invalid BikeId.");
            }

            var res = _bikeRepository.ChangeState(BikeId, state);

            return res;
        }

        public async Task<bool> AddBike(Bike entity)
        {

                entity.BikeId = Guid.NewGuid();
                entity.CreatedAt = DateTime.UtcNow;
                entity.LastUpdatedAt = DateTime.UtcNow;
                entity.ChangeState(BikeState.Available);

                bool res = await _bikeRepository.AddAsync(entity);

                return res;
        }

        public async Task<bool> DeleteBike(Guid BikeId)
        {
            if (BikeId == Guid.Empty) 
            {
                throw new ApplicationException("Invalid BikeId.");
            }

            bool res = await _bikeRepository.DeleteAsync(BikeId);

            return res;
        }
    }
}
