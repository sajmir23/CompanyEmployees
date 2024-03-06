using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        [Required(ErrorMessage = "Comment is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the comment is 100 characters.")]
        public string? Comment {  get; set; }
    }
}
