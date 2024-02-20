using Contracts;
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
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IApartmentRepository> _apartmentRepository;

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
        }
        public ICompanyRepository Company => _companyRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;
        public IBookRepository Book => _bookRepository.Value;
        public IUserRepository User => _userRepository.Value;
        public IApartmentRepository Apartment => (IApartmentRepository)_apartmentRepository.Value;

     
        public void Save() => _repositoryContext.SaveChanges();
    }
}
