
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICarService
    {
        IEnumerable<CarDto> GetAllCars(bool trackChanges);
        CarDto GetCar(Guid Id,bool trackChanges);
        CarDto CreateCar(CreateCarDto car);
        void DeleteCar(Guid Id,bool trackChanges);
        

    }
}
