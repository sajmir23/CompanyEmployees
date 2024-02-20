using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Street { get; set;}

        public string City { get; set; }
    }
}
