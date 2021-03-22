using System;
using System.Collections.Generic;

#nullable disable

namespace Common.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
            EstudianteDireccions = new HashSet<EstudianteDireccion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<EstudianteDireccion> EstudianteDireccions { get; set; }
    }
}
