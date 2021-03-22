using System;
using System.Collections.Generic;

#nullable disable

namespace Common.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            EstudianteCursos = new HashSet<EstudianteCurso>();
            EstudianteDireccions = new HashSet<EstudianteDireccion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual ICollection<EstudianteDireccion> EstudianteDireccions { get; set; }
    }
}
