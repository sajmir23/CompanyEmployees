using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CarRepository: RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }


        public IEnumerable<Car> GetAllCars(bool trackChanges) =>
         FindAll(trackChanges)
         .OrderBy(c => c.Modeli)
         .ToList();

        public void CreateCar(Car carnm) => Create(carnm);
        
    }

     
}
