using Common.DAOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeStone.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly ILogger<EstudianteController> _logger;

        public EstudianteController(ILogger<EstudianteController> logger)
        {
            _logger = logger;
        }
        public IActionResult Leer()
        {
            var estudianteDao = new EstudianteDAO();
            var modelo = new List<EstudianteModel>();
            try
            {
                var estudiantes = estudianteDao.ObtenerEstudiantes();
                foreach (var estudiante in estudiantes)
                {
                    modelo.Add(new EstudianteModel { Id = estudiante.Id, Nombre = estudiante.Nombre, Edad = estudiante.Edad, Telefono = estudiante.Telefono });
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
        public ActionResult Crear(EstudianteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var estudianteDao = new EstudianteDAO();
                    estudianteDao.InsertarEstudiante(new Modelos.DTOs.EstudianteDTO { Id = model.Id, Nombre = model.Nombre, Edad = model.Edad, Telefono = model.Telefono });
                }

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
            var estudianteDao = new EstudianteDAO();
            var modelo = new EstudianteModel();
            var estudiante = estudianteDao.ObtenerEstudiante(id);
            modelo.Id = id;
            modelo.Nombre = estudiante.Nombre;
            modelo.Edad = estudiante.Edad;
            modelo.Telefono = estudiante.Telefono;
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(EstudianteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var estudianteDao = new EstudianteDAO();
                    estudianteDao.ActualizarEstudiante(new Modelos.DTOs.EstudianteDTO { Id = model.Id, Nombre = model.Nombre, Edad = model.Edad, Telefono = model.Telefono });
                }

                return Redirect("~/estudiante/leer");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        //UTILIZA JSON WEB TOKEN

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
                    var estudianteDao = new EstudianteDAO();
                    estudianteDao.EliminarEstudiante(id);
                }

                return Redirect("~/estudiante/leer");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
    }
}
