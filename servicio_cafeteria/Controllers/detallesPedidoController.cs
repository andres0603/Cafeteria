using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class detallesPedidoController : ControllerBase
    {
        private IdetallesPedidoNegocio? IdetallesPedidoNegocio;

        public detallesPedidoController()
        {
            this.IdetallesPedidoNegocio = new detallesPedidoNegocio();
        }

        [HttpGet]
        public List<detallesPedido> Consultar()
        {
            if (this.IdetallesPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IdetallesPedidoNegocio!.Consultar();
        }

        [HttpPost]
        public detallesPedido Guardar(detallesPedido entidad)
        {
            if (this.IdetallesPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IdetallesPedidoNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public detallesPedido Modificar(detallesPedido entidadModificada)
        {
            if (this.IdetallesPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IdetallesPedidoNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IdetallesPedidoNegocio!.Borrar(id);
                return Ok("Detalle del pedido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{detalleId}")]
        public decimal calcularSubTotal(int detalleId)
        {
            if (this.IdetallesPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IdetallesPedidoNegocio!.calcularSubTotal(detalleId);

        }
    }
}
