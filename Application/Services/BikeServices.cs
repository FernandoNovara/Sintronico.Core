using Application.DTOs;
using Domain.Interfaces;

namespace Application.Services
{
    public class BikeServices
    {
        public bool ValidationBike(int page = 1, int pageSize = 10, string? category = null)
        {
            if (page > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
