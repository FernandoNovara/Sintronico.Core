using Application.DTOs;
using Domain.Interfaces;

namespace Application.Services
{
    public class BikeServices
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeServices(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task<List<BikeDTO>> GetAllBikes()
        {
            var list = await _bikeRepository.GetAllAsync();
            return list.Select(b => new BikeDTO
            {
                BikeId = b.BikeId,
                Model = b.Model,
                Category = b.Category
            }).ToList();
        }
    }
}
