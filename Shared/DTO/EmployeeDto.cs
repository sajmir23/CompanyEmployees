using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmployeeDto(Guid Id, string Name, int Age, string Position);

    public record EmployeeForCreation : EmployeeForManipulationDto
    {

        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Age is a required field.")]
        [Range(18, int.MaxValue, ErrorMessage = "Age is a required field and can't be lower than 18")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? Position { get; init; }
    }

    public record EmployeeForUpdateDto : EmployeeForManipulationDto
    {
        [Required(ErrorMessage="Name is a required field.")]
        [MaxLength(30,ErrorMessage ="shouldn't be lower than 30")]
        public string? Name { get; set;}

        [Required(ErrorMessage ="Age is a required field.")]
        [Range(18,int.MaxValue,ErrorMessage="shouldn't be lower than 18")]
        public int? Age {  get; set; }

        [Required(ErrorMessage ="Position is a required field.")]
        [MaxLength(20,ErrorMessage="shouldn't be less than 20")]
        public string? Position { get; set;}    

    }
}
