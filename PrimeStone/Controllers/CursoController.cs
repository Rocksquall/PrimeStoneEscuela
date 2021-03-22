using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeStone.Models;
using Common.DAOs;

namespace PrimeStone.Controllers
{
    public class CursoController : Controller
    {
        private readonly ILogger<CursoController> _logger;

        public CursoController(ILogger<CursoController> logger)
        {
            _logger = logger;
        }
        public IActionResult Leer()
        {
            var cursoDao = new CursoDAO();
            var modelo = new List<CursoModel>();
            try
            {
                var cursos = cursoDao.ObternerCursos();
                foreach (var curso in cursos)
                {
                    modelo.Add(new CursoModel { Id = curso.Id, Nombre = curso.Nombre, Tiempo = curso.Tiempo, FechaInicio = (Convert.ToDateTime(curso.FechaInicio)), FechaFin = Convert.ToDateTime(curso.FechaFin) });
                }

                return View(modelo);

            }
            catch (Exception ex)
            {
                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        public ActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Crear(CursoModel model)
        {
            try
            {

                    var cursoDao = new CursoDAO();
                    cursoDao.InsertarCurso(new Modelos.DTOs.CursoDTO { Id = model.Id, Nombre = model.Nombre, Tiempo = model.Tiempo, FechaInicio = Convert.ToString(model.FechaInicio.ToString("dd/MM/yyyy")), FechaFin = Convert.ToString(model.FechaFin.ToString("dd/MM/yyyy")) });


                return Redirect("leer");

            }
            catch (Exception ex)
            {
                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        public ActionResult Editar(int id)
        {
            var cursoDao = new CursoDAO();
            var modelo = new CursoModel();
            var curso = cursoDao.ObternerCurso(id);
            modelo.Id = id;
            modelo.Nombre = curso.Nombre;
            modelo.Tiempo = curso.Tiempo;
            modelo.FechaInicio = Convert.ToDateTime(curso.FechaInicio);
            modelo.FechaFin = Convert.ToDateTime(curso.FechaFin);
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(CursoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cursoDao = new CursoDAO();
                    cursoDao.ActualizarCurso(new Modelos.DTOs.CursoDTO { Id = model.Id, Nombre = model.Nombre, Tiempo = model.Tiempo, FechaInicio = Convert.ToString(model.FechaInicio.ToString("dd/MM/yyyy")), FechaFin = Convert.ToString(model.FechaFin.ToString("dd/MM/yyyy")) });
                }

                return Redirect("~/Curso/leer");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        public ActionResult Eliminar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cursoDao = new CursoDAO();
                    cursoDao.EliminarCurso(id);
                }

                return Redirect("~/Curso/Leer");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
    }
}
