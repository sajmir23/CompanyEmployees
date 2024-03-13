using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    
    public class Car
    { 
        [Key]
        public int Id { get; set; }
        public string Modeli { get; set; }

        [Required(ErrorMessage ="Fusha e kerkuar eshte e detyrueshme")]
        [MaxLength(100, ErrorMessage = "Fusha e kerkuar duhet te jete 100 karaktere.")]
        public string Pershkrimi { get; set; }

        public int VitProdhim { get; set; }
    }
}
