using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class estadosPedidoController : ControllerBase
    {

        private IEstadosPedidoNegocio? IEstadosPedidoNegocio;

        public estadosPedidoController()
        {
            this.IEstadosPedidoNegocio = new estadosPedidoNegocio();
        }

        [HttpGet]
        public List<estadosPedido> Consultar()
        {
            if (this.IEstadosPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosPedidoNegocio!.Consultar();
        }

        [HttpPost]
        public estadosPedido Guardar(estadosPedido entidad)
        {
            if (this.IEstadosPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosPedidoNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public estadosPedido Modificar(estadosPedido entidadModificada)
        {
            if (this.IEstadosPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosPedidoNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IEstadosPedidoNegocio!.Borrar(id);
                return Ok("Estado del pedido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
    }
}
