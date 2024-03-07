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
        [Key]
        public int Id { get; set; }

        [Range(1,5,ErrorMessage ="Rating must be between 1 until 5")]
        public string Rating { get; set; }

        [Required(ErrorMessage = "Comment is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the comment is 100 characters.")]
        public string? Comment {  get; set; }
    }
}
