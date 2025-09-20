using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BikeDTO
    {
        public Guid BikeId { get; set; }

        public string Model { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
