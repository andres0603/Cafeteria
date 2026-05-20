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
        public List<estadoReserva> Consultar()
        {
            if (this.IEstadoReservaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoReservaNegocio!.Consultar();
        }

        [HttpPost]
        public estadoReserva Guardar(estadoReserva entidad)
        {
            if (this.IEstadoReservaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoReservaNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public estadoReserva Modificar(estadoReserva entidadModificada)
        {
            if (this.IEstadoReservaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadoReservaNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IEstadoReservaNegocio!.Borrar(id);
                return Ok("Estado de reserva eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
