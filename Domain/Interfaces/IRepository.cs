using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(int page = 1, int pageSize = 10, string? category = null);
    }
}
