using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class estadoReservaController : ControllerBase
    {

        private IEstadoReservaNegocio? IEstadoReservaNegocio;

        public estadoReservaController()
        {
            this.IEstadoReservaNegocio = new estadoReservaNegocio();
        }

        [HttpGet]
        public List<estadoReserva> Consultar(string usuario)
        {
            if (this.IEstadoReservaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoReservaNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public estadoReserva Guardar(estadoReserva entidad, string usuario)
        {
            if (this.IEstadoReservaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoReservaNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public estadoReserva Modificar(estadoReserva entidadModificada, string usuario)
        {
            if (this.IEstadoReservaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoReservaNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public estadoReserva Borrar(estadoReserva entidad, string usuario)
        {
            if (this.IEstadoReservaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoReservaNegocio!.Borrar(entidad, usuario);
        }
            
    }
}
