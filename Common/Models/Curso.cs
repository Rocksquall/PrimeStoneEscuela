using System;
using System.Collections.Generic;

#nullable disable

namespace Common.Models
{
    public partial class Curso
    {
        public Curso()
        {
            EstudianteCursos = new HashSet<EstudianteCurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tiempo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        public virtual ICollection<EstudianteCurso> EstudianteCursos { get; set; }
    }
}
