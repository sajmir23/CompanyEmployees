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

        public Car GetCar(int id, bool trackChanges) =>
        FindByCondition(c=>c.Id.Equals(id),trackChanges) 
        .FirstOrDefault();

        public void CreateCar(Car car) => Create(car);

        public void DeleteCar(Car car) => Delete(car);
    }

     
}
