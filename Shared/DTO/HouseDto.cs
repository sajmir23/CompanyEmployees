using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record HouseDto
    {
        public string? Placed { get; set; }
        public int? Neighborhood { get; set; }
        public int? NumofRooms { get; set; }
    }
}
