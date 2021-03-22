using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTOs
{
   public class CursoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tiempo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
