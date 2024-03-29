﻿using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DTO;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForMember(c => c.FullAddress,
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<ReviewDto, Review>();
            CreateMap<EmployeeForCreation, Employee>();
            CreateMap<HouseDto, House>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            CreateMap<CompanyForUpdateDto,Company>();

           CreateMap<CreateCarDto,Car>().ReverseMap(); 
           CreateMap<CarDto, Car>().ReverseMap();

            CreateMap<UserForRegistrationDto, User>();


        }
    }
}
