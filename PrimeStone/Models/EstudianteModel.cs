using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeStone.Models
{
    public class EstudianteModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Edad { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
    }
}
