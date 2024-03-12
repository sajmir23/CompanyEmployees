﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects 
{
    [Serializable]

    public record CompanyDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? FullAddress { get; init; }
    }
    public record CompanyForCreationDto(string Name,string Address,string Country,IEnumerable<EmployeeForCreation> Employees);
    public record CompanyForUpdateDto(string Name, string Address, string Country,IEnumerable<EmployeeForCreation>? Employees);
}
