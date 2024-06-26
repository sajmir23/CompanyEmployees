﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Identity.Client;
using Service.Contracts;
using Shared;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService: IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly IDapperRepository _dapperRepository;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper,IDapperRepository dapperRepository)
        {
            _loggerManager = logger;
            _repositoryManager = repository;
            _mapper = mapper;
            _dapperRepository = dapperRepository;
            
        }
        
        private async Task CheckIfCompanyExists(Guid companyId, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId,
           trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
        }

        private async Task<Employee> GetEmployeeForCompanyAndCheckIfItExists(Guid companyId, Guid id, bool trackChanges)
        {
            var employeeDb = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id,trackChanges);
            if (employeeDb is null)
                throw new EmployeeNotFoundException(id);

            return employeeDb;
        }
        
        public async Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters,bool trackChanges)
        {
            if (!employeeParameters.ValidAgeRange) 
            throw new MaxAgeRangeBadRequestException(); 

            await CheckIfCompanyExists(companyId, trackChanges);

            var employeesWithMetaData = await _repositoryManager.Employee.GetEmployeesAsync(companyId,employeeParameters,trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

            return (employees:employeesDto,metaData:employeesWithMetaData.MetaData);

        }
        
        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists (companyId, trackChanges);
      
            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists (companyId, id, trackChanges);
           

            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }


         public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreation employeeForCreation, bool trackChanges)
         {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

            _repositoryManager.Employee.CreateEmployeeForCompany(companyId,employeeEntity);

            await _repositoryManager.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeToReturn;

         }

        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId,trackChanges);
            if(company is null)
            { 
                throw new CompanyNotFoundException(companyId);
            }
            var employeeForCompany = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id, trackChanges);
            if(employeeForCompany is null)
            {
                throw new EmployeeNotFoundException(id);
            }
            _repositoryManager.Employee.DeleteEmployee(employeeForCompany);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate,bool compTrackChanges, bool empTrackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id, empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(id);

            _mapper.Map(employeeForUpdate, employeeEntity);
             await _repositoryManager.SaveAsync();
        }

        public async Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            var company =  await _repositoryManager.Company.GetCompanyAsync(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = await _repositoryManager.Employee.GetEmployeeAsync(companyId, id,empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(companyId);

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            return (employeeToPatch, employeeEntity);
        }

        public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee
        employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);
             _repositoryManager.Save();
        }

    }
}