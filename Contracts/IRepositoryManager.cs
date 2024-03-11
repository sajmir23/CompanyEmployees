using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IBookRepository Book { get; }
        IApartmentRepository Apartment { get; }
        IUserRepository User { get; }
        IReviewRepository Review { get; }
        IHouseRepository House { get; }
        ICarRepository Car { get; }
        void Save();
    }
}
