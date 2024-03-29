using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses
{
    public sealed class CompanyNotFoundResponse : ApiNotFoundResponse
    {
        public CompanyNotFoundResponse(Guid id) : base($"Company with this id {id} not found in db")
        { }
    }
}
