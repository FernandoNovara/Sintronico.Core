using Application.Interfaces;
using Application.Mappers;
using Domain.Interfaces;

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
    }
}
