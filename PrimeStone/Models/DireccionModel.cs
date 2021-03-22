using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeStone.Models
{
    public class DireccionModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
