﻿using Entities.Responses;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);
        Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges);

        //ApiBaseResponse GetAllCompanies(bool trackChanges);
        //ApiBaseResponse GetCompany(Guid companyId, bool trackChanges);


        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);
        
        Task DeleteCompanyAsync(Guid companyId,bool trackChanges);

        Task UpdateCompanyAsync(Guid companyId,CompanyForUpdateDto companyForUpdateDto, bool  trackChanges);


        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection);

    }
}
