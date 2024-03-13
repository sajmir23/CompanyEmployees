using Contracts;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IApartmentRepository> _apartmentRepository;
        private readonly Lazy<IReviewRepository> _reviewRepository;
        private readonly Lazy<IHouseRepository> _houseRepository;
        private readonly Lazy<ICarRepository> _carRepository;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new
            CompanyRepository(repositoryContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new
            EmployeeRepository(repositoryContext));
            _bookRepository = new Lazy<IBookRepository>(() => new
            BookRepository(repositoryContext));
            _userRepository = new Lazy<IUserRepository>(() => new
            UserRepository(repositoryContext));
            _apartmentRepository = new Lazy<IApartmentRepository>(() => new
            AparmentRepository(repositoryContext));
            _reviewRepository = new Lazy<IReviewRepository>(() => new
            ReviewRepository(repositoryContext));
            _houseRepository = new Lazy<IHouseRepository>(() => new
            HouseRepository(repositoryContext));
            _carRepository = new Lazy<ICarRepository>(() => new
            CarRepository(repositoryContext));
        }
        public ICompanyRepository Company => _companyRepository.Value;
        public IEmployeeRepository Employee
        {
            get
            {
                _employeeRepository ??= new Lazy<IEmployeeRepository>();
                return _employeeRepository.Value;
            }
        }
        public IBookRepository Book => _bookRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public IApartmentRepository Apartment => (IApartmentRepository)_apartmentRepository.Value;
        public IReviewRepository Review => _reviewRepository.Value;
        public IHouseRepository House => _houseRepository.Value;
        public ICarRepository Car => _carRepository.Value;


        public void Save() => _repositoryContext.SaveChanges();
    }
}
