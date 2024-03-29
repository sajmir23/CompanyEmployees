﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICompanyService CompanyService { get; }

        IEmployeeService EmployeeService { get; }

        IReviewService ReviewService { get; }

        IHouseService HouseService { get; }

        ICarService CarService  { get; }

        IAuthenticationService AuthenticationService { get; }

    }
}
