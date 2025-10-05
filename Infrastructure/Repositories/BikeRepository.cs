using Application.DTOs;
using Application.Services;
using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Services
{
    public class BikeRepository : IBikeRepository
    {
        private readonly SintronicoDBContext _context;
        private readonly BikeServices _bikeServices;

        public BikeRepository(SintronicoDBContext context, BikeServices bikeServices)
        {
            _context = context;
            _bikeServices = bikeServices;
        }

        public async Task<PagedResult<Bike>> GetAllAsync(int page = 1, int pageSize = 10, string? category = null)
        {
            try 
            {
                PagedResult<Bike> bikes = new PagedResult<Bike>();

                if (_bikeServices.ValidationBike(page, pageSize, category))
                {
                    var bikeEntity = await _context.Bikes.ToListAsync();

                    if (!string.IsNullOrWhiteSpace(category))
                    {
                        bikeEntity = bikeEntity.Where(x => x.Category == category).ToList();
                    }

                    var total = bikeEntity.Count();

                    var items = bikeEntity
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                    return new PagedResult<Bike>
                    {
                        page = page,
                        pageSize = pageSize,
                        total = total,
                        items = items
                    };
                }

                return bikes;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving bikes.", ex);
            }
        }
    }
}
