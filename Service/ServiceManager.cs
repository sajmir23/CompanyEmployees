using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IReviewService> _reviewService;
        private readonly Lazy<IHouseService> _houseService;
        private readonly Lazy<ICarService> _carService;
        private readonly Lazy<IAuthenticationService> _authenticationService;


        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger,
            IMapper mapper,UserManager<User> userManager,IConfiguration configuration,IDapperRepository dapperRepository)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper,dapperRepository));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper,dapperRepository));
            _reviewService = new Lazy<IReviewService>(() => new ReviewService(repositoryManager, logger, mapper));
            _houseService = new Lazy<IHouseService>(() => new HouseService(repositoryManager, logger, mapper));
            _carService = new Lazy<ICarService>(() => new CarService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, configuration));
        }

        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public IReviewService ReviewService => _reviewService.Value;
        public IHouseService HouseService => _houseService.Value;
        public ICarService CarService => _carService.Value;
        public IAuthenticationService AuthenticationService =>_authenticationService.Value;
    }

    
}
