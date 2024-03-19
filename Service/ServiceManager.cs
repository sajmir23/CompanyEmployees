using AutoMapper;
using Contracts;
using Microsoft.EntityFrameworkCore.Metadata;
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


        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper));
            _reviewService = new Lazy<IReviewService>(() => new ReviewService(repositoryManager, logger, mapper));
            _houseService = new Lazy<IHouseService>(() => new HouseService(repositoryManager, logger, mapper));
            _carService = new Lazy<ICarService>(() => new CarService(repositoryManager, logger, mapper));
        }



        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public IReviewService ReviewService => _reviewService.Value;
        public IHouseService HouseService => _houseService.Value;
        public ICarService CarService => _carService.Value;
    }

    
}
