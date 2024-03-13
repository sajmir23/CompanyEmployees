using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public record CompanyForCreationDto
    {
        [Required(ErrorMessage ="Name is a required field")]
        [MaxLength(20,ErrorMessage ="Name should be no higher than 20.")]
        public string? Name { get; set;}
        [Required(ErrorMessage ="Address is a required field")]
        [MaxLength(30,ErrorMessage ="Address should be no higher 30.")]
        public string? Address {  get; set;}
        [Required(ErrorMessage ="Country is a required field.")]
        [MaxLength(40,ErrorMessage ="fdgaergferg")]
        public string? Country {  get; set;}
        [Required(ErrorMessage ="Employees is a required field.")]
        public IEnumerable<EmployeeForCreation>? Employees {  get; set;}
    };
    public record CompanyForUpdateDto(string Name, string Address, string Country,IEnumerable<EmployeeForCreation>? Employees);
}
