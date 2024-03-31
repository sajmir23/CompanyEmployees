using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Employee name is a required field")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? Position { get; set; }


        [ForeignKey(nameof(Company))]  //ketu behet lidhja ne nivel databaze midis kompanise dhe punonjesit dhe percakton qe companiId do t ejet celsi i jashtem qe do te behet lidhja ndermjet klasave
        public Guid CompanyId { get; set; }   //CompanyId quhet celsi i jashtem per te lidh klasen company me employee
        public Company? Company { get; set; }
    }
}


