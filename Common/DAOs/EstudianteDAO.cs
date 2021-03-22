using Common.Models;
using Microsoft.EntityFrameworkCore;
using Modelos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAOs
{
    public class EstudianteDAO
    {


        //Leer Estudiantes
        public List<EstudianteDTO> ObtenerEstudiantes()
        {
            var estudiantes = new List<EstudianteDTO>();
            using (var db = new BDEscuelaContext())
            {
                estudiantes = (from e in db.Estudiantes
                               select new EstudianteDTO
                               {
                                   Id = e.Id,
                                   Nombre = e.Nombre,
                                   Edad = e.Edad,
                                   Telefono = e.Telefono

                               }).ToList();
            }
            return estudiantes;
        }

        public EstudianteDTO ObtenerEstudiante(int id)
        {
            var estudiante = new EstudianteDTO();
            using (var db = new BDEscuelaContext())
            {
                var _estudiantes = db.Estudiantes.Find(id);
                estudiante.Id = _estudiantes.Id;
                estudiante.Nombre = _estudiantes.Nombre;
                estudiante.Edad = _estudiantes.Edad;
                estudiante.Telefono = _estudiantes.Telefono;
            }
            return estudiante;
        }



        //Crear Estudiantes
        public EstudianteDTO InsertarEstudiante(EstudianteDTO estudiante)
        {
            var _estudiante = new Estudiante();
            using (var db = new BDEscuelaContext())
            {
                _estudiante.Id = estudiante.Id;
                _estudiante.Nombre = estudiante.Nombre;
                _estudiante.Edad = estudiante.Edad;
                _estudiante.Telefono = estudiante.Telefono;
                db.Estudiantes.Add(_estudiante);
                db.SaveChanges();
            }
            return estudiante;
        }


        //Actualizar Estudiantes
        public void ActualizarEstudiante(EstudianteDTO estudiante)
        {
            using (var db = new BDEscuelaContext())
            {
                var _estudiante = new Estudiante();
                _estudiante.Id = estudiante.Id;
                _estudiante.Nombre = estudiante.Nombre;
                _estudiante.Edad = estudiante.Edad;
                _estudiante.Telefono = estudiante.Telefono;
                db.Entry(_estudiante).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        //Eliminar Estudiantes
        public void EliminarEstudiante(int id)
        {
            using (var db = new BDEscuelaContext())
            {
                var _estudiante = db.Estudiantes.Find(id);
                db.Estudiantes.Remove(_estudiante);
                db.SaveChanges();
            }
        }



    }
}
