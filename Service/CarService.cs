using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CarService: ICarService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CarService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {

            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
       public IEnumerable<CarDto> GetAllCars(bool trackChanges)
       {
            var cars = _repository.Car.GetAllCars(trackChanges);
            var cardto = _mapper.Map<IEnumerable<CarDto>>(cars);
            return cardto;

       }
        public CarDto GetCar(Guid id,bool trackChanges) 
        {
            var car =_repository.Car.GetCar(id, trackChanges);
            var cardto =_mapper.Map<CarDto>(car);
            return cardto;

        }

        public CarDto CreateCar(CreateCarDto car) 
        {
            var carcreated = _mapper.Map<Car>(car);
            _repository.Car.CreateCar(carcreated);
            _repository.Save();
            var carEntity = _mapper.Map<CarDto>(carcreated);

            return carEntity;
        }
        public void DeleteCar(Guid Id, bool trackChanges)
        {
            var car =_repository.Car.GetCar(Id, trackChanges);
            if(car is null)
            {
                throw new CarNotFoundException(Id);
            }
            _repository.Car.DeleteCar(car);
            _repository.Save();


        }



    }
}
