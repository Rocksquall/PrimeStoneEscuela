using Common.DAOs;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeStone.Service
{
    public class GuardarFechaServicio : IHostedService, IDisposable
    {
        private Timer timer;

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(40));
            return Task.CompletedTask;
        }

        //Guarda Direcciones random en la tabla Direcciones base de datos
        private void DoWork(object state)
        {
            var DireccionesDao = new DireccionDAO();
            Random rnd = new Random();
            int number = rnd.Next(0, 100);
            var direccion = "Diagonal Aleatoria #" + number + "";
            DireccionesDao.InsertarDireccion(new Modelos.DTOs.DireccionDTO { Id = 0, Nombre = direccion });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
    }
}
