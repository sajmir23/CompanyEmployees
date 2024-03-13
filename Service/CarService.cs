﻿using AutoMapper;
using Contracts;
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
        public CarDto CreateCar(CreateCarDto car) 
        {
            var carcreated = _mapper.Map<Car>(car);
            _repository.Car.CreateCar(carcreated);
            var carEntity = _mapper.Map<CarDto>(carcreated);

            return carEntity;
        }
    }
}
