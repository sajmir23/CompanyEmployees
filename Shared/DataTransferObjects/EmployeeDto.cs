using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmployeeDto(Guid Id,String Name,int Age,String Position);

    public record EmployeeForCreation(string Name,int Age,string Position);
    public record EmployeeForUpdateDto(string Name, int Age, string Position);
}
