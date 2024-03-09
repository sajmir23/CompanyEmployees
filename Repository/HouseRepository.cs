using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HouseRepository : RepositoryBase<House>, IHouseRepository
    {
        public HouseRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<House> GetAllHouse(bool trackChanges) =>
         FindAll(trackChanges)
            .OrderBy(c => c.Placed)
            .ToList();

        public void CreateHouse(House house)=>Create(house);


    }
}
