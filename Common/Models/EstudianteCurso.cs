using System;
using System.Collections.Generic;

#nullable disable

namespace Common.Models
{
    public partial class EstudianteCurso
    {
        public int IdEstudianteCurso { get; set; }
        public int? Estudiante { get; set; }
        public int? Curso { get; set; }

        public virtual Curso CursoNavigation { get; set; }
        public virtual Estudiante EstudianteNavigation { get; set; }
    }
}
