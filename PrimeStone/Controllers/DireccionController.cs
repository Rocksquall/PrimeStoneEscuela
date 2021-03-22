using Common.DAOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrimeStone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeStone.Controllers
{
    public class DireccionController : Controller
    {
        private readonly ILogger<DireccionController> _logger;

        public DireccionController(ILogger<DireccionController> logger)
        {
            _logger = logger;
        }
        public IActionResult Leer()
        {
            var DireccionesDAO = new DireccionDAO();
            var modelo = new List<DireccionModel>();
            try
            {
                var direcciones = DireccionesDAO.ObternerDirecciones();
                foreach (var direccion in direcciones)
                {
                    modelo.Add(new DireccionModel { Id = direccion.Id, Nombre = direccion.Nombre });
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
        public ActionResult Crear(DireccionModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DireccionesDAO = new DireccionDAO();
                    DireccionesDAO.InsertarDireccion(new Modelos.DTOs.DireccionDTO { Id = model.Id, Nombre = model.Nombre });
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
            var DireccionesDAO = new DireccionDAO();
            var modelo = new DireccionModel();
            var Direcciones = DireccionesDAO.ObternerDireccion(id);
            modelo.Id = id;
            modelo.Nombre = Direcciones.Nombre;
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(DireccionModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DireccionesDAO = new DireccionDAO();
                    DireccionesDAO.ActualizarDireccion(new Modelos.DTOs.DireccionDTO { Id = model.Id, Nombre = model.Nombre });
                }

                return Redirect("~/direccion/leer");

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
                    var DireccionesDAO = new DireccionDAO();
                    DireccionesDAO.EliminarDireccion(id);
                }

                return Redirect("~/direccion/leer");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
    }
}
