using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Placed {  get; set; }
        public int Neighborhood {  get; set; }
        public int NumofRooms {  get; set; }
    }
}
