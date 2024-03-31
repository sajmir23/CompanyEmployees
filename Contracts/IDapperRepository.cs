using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDapperRepository
    {
            public Task<IEnumerable<Company>> GetCompanies();
            public Task<Company> GetCompany(int id);
            public Task<Company> CreateCompany(CompanyForCreationDto company);
            public Task UpdateCompany(int id, CompanyForUpdateDto company);
            public Task DeleteCompany(int id);
            public Task<Company> GetCompanyByEmployeeId(int id);
    }
}
