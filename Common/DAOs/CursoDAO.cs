using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Modelos.DTOs;

namespace Common.DAOs
{
    class CursoDAO
    {

        //Leer Curso
        public List<CursoDTO> ObternerCursos()
        {
            var cursos = new List<CursoDTO>();
            using (var db = new BDEscuelaContext())
            {
                cursos = (from e in db.Cursos
                          select new CursoDTO
                          {
                              Id = e.Id,
                              Nombre = e.Nombre,
                              Tiempo = e.Tiempo,
                              FechaInicio = e.FechaInicio,
                              FechaFin = e.FechaFin

                          }).ToList();
            }
            return cursos;
        }

        public CursoDTO ObternerCurso(int id)
        {
            var curso = new CursoDTO();
            using (var db = new BDEscuelaContext())
            {
                var _curso = db.Cursos.Find(id);
                curso.Id = _curso.Id;
                curso.Nombre = _curso.Nombre;
                curso.Tiempo = _curso.Tiempo;
                curso.FechaInicio = _curso.FechaInicio;
                curso.FechaFin = _curso.FechaFin;
            }
            return curso;
        }



        //crear
        public CursoDTO InsertarCurso(CursoDTO curso)
        {
            var _curso = new Curso();
            using (var db = new BDEscuelaContext())
            {
                _curso.Nombre = curso.Nombre;
                _curso.Tiempo = curso.Tiempo;
                _curso.FechaInicio = curso.FechaInicio;
                _curso.FechaFin = curso.FechaFin;
                db.Cursos.Add(_curso);
                db.SaveChanges();
            }
            return curso;
        }



        //Update, Actualizar
        public void ActualizarCurso(CursoDTO curso)
        {
            using (var db = new BDEscuelaContext())
            {
                var _curso = new Curso();
                _curso.Id = curso.Id;
                _curso.Nombre = curso.Nombre;
                _curso.Tiempo = curso.Tiempo;
                _curso.FechaInicio = curso.FechaInicio;
                _curso.FechaFin = curso.FechaFin;
                db.Entry(_curso).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        //Eliminar
        public void EliminarCurso(int id)
        {
            using (var db = new BDEscuelaContext())
            {
                var _curso = db.Cursos.Find(id);
                db.Cursos.Remove(_curso);
                db.SaveChanges();
            }
        }



    }

}

