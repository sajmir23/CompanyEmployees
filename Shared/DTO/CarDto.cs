using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    [Serializable]

    public record class CarDto
    {
        public Guid Id { get; set; }
        public string? Modeli { get; set; }
        public int? VitProdhim { get; set; }
    }

    public record class CreateCarDto
    {
        public string Modeli { get; set; }
        public string Pershkrimi { get; set; }
        public int VitProdhim { get; set; }
    }
}
