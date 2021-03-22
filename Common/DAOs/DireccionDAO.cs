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
    public class DireccionDAO
    {

        // Leer Direcciones
        public List<DireccionDTO> ObternerDirecciones()
        {
            var direcciones = new List<DireccionDTO>();
            using (var db = new BDEscuelaContext())
            {
                direcciones = (from e in db.Direcciones
                               select new DireccionDTO
                               {
                                   Id = e.Id,
                                   Nombre = e.Nombre,
                               }).ToList();
            }
            return direcciones;
        }

        public DireccionDTO ObternerDireccion(int id)
        {
            var direccion = new DireccionDTO();
            using (var db = new BDEscuelaContext())
            {
                var _direccion = db.Direcciones.Find(id);
                direccion.Id = _direccion.Id;
                direccion.Nombre = _direccion.Nombre;
            }
            return direccion;
        }



        //Crear Direcciones
        public DireccionDTO InsertarDireccion(DireccionDTO direccion)
        {
            var _direccion = new Direccion();
            using (var db = new BDEscuelaContext())
            {
                _direccion.Id = direccion.Id;
                _direccion.Nombre = direccion.Nombre;
                db.Direcciones.Add(_direccion);
                db.SaveChanges();
            }
            return direccion;
        }



        //Update o actualizar
        public void ActualizarDireccion(DireccionDTO direccion)
        {
            using (var db = new BDEscuelaContext())
            {
                var _direccion = new Direccion();
                _direccion.Id = direccion.Id;
                _direccion.Nombre = direccion.Nombre;
                db.Entry(_direccion).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        //Eliminar Direcciones
        public void EliminarDireccion(int id)
        {
            using (var db = new BDEscuelaContext())
            {
                var _direccion = db.Direcciones.Find(id);
                db.Direcciones.Remove(_direccion);
                db.SaveChanges();
            }
        }


    }
}
