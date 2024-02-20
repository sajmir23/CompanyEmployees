using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService:IEmployeeRepository
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public EmployeeService(ILoggerManager logger,IRepositoryManager repository)
        {
            _loggerManager = logger;
            _repositoryManager = repository;
        }
    }
}
