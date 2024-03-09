using AutoMapper;
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
    internal sealed class HouseService: IHouseService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public HouseService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {

            _repositoryManager = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<HouseDto> GetAllHouse(bool trackChanges)
        {
            var house = _repositoryManager.House.GetAllHouse(trackChanges);
            var houseDto =_mapper.Map<IEnumerable<HouseDto>>(house);
            return houseDto;
        }

        public House AddHouse(HouseDto houseDto)
        {

            var houseEntity = _mapper.Map<House>(houseDto);
            _repositoryManager.House.CreateHouse(houseEntity);
            _repositoryManager.Save();

            return houseEntity;
        }

    
    }
    
}
