using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class EmployeeParameters : RequestParameters
    {
        //Sorting
        public EmployeeParameters() => OrderBy = "name"; //kjo eshte nje query string 
                                                          // query eshte Orderby
                                                          // dhe name eshte string-u  
        //Filtrimi
        public uint MinAge { get; set; }
        public uint MaxAge { get; set; } = int.MaxValue;
        public bool ValidAgeRange => MaxAge > MinAge;

        //Searching
        public string? SearchTerm { get; set; }

    }
}
