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

        public async Task<List<Bike>> GetAllAsync()
        {
            return await _context.Bikes.ToListAsync();
        }
    }
}
