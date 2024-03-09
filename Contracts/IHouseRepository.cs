using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHouseRepository
    {
        IEnumerable<House> GetAllHouse(bool trackChanges);
        void CreateHouse(House house);
    }
}
