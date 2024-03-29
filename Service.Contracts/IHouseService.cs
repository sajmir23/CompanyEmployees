﻿using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IHouseService
    {
        public IEnumerable<HouseDto> GetAllHouse(bool trackChanges);

        public House AddHouse(HouseDto houseDto);
    }
}
