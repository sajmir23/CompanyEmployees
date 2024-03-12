using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmployeeDto(Guid Id, String Name, int Age, String Position);

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
        [Required(ErrorMessage ="Name is a required field.")]
        [MaxLength(30,ErrorMessage ="Max length is 30 characters.")]
        public string? Name {  get; init; }

        [Required(ErrorMessage="Age is a required field.")]
        [Range(18,int.MaxValue,ErrorMessage="Age must'n be lower than 18.")]
        public int? Age { get; init; }

        [Required(ErrorMessage ="Position is a required field")]
        [MaxLength(20,ErrorMessage ="Position must'n be lower than 20.")]
        public string? Position { get; init; }
    }
}
