
using Entities.Responses;

namespace CompanyEmployees.Extensions.ApiBaseResponseExtensions
{
    public static class ApiBaseResponseExtensions
    {
        public static TResultType GetResult<TResultType>(this ApiBaseResponse
        apiBaseResponse) =>
        ((ApiOkResponse<TResultType>)apiBaseResponse).Result;
    }
}
