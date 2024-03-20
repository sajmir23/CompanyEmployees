using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CarNotFoundException : NotFoundException
    {
        public CarNotFoundException(int Id) : base($"Car with id: {Id} doesn;t exist in the database.")
        { }
    }
}
