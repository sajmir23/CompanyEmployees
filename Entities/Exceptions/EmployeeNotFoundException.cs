using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class EmployeeNotFoundException:NotFoundException
    {
        public EmployeeNotFoundException(Guid employeeId):base($"EmployeeNotFoundException with id:{employeeId} doesn't exist in the database")
        { }

    }
}
