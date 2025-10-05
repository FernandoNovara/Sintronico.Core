using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PagedResult<T>
    {
        public int page { get; set; }

        public int pageSize { get; set; }

        public int total { get; set; }

        public List<T> items { get; set; } = new List<T>();
    }
}
