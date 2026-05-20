using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class pedidosController : ControllerBase
    {

        private IPedidosNegocio? IPedidosNegocio;

        public pedidosController()
        {
            this.IPedidosNegocio = new pedidosNegocio();
        }

        [HttpGet]
        public List<pedidos> Consultar()
        {
            if (this.IPedidosNegocio == null)
                throw new Exception("No implementado");
            return this.IPedidosNegocio!.Consultar();
        }

        [HttpPost]
        public pedidos Guardar(pedidos entidad)
        {
            if (this.IPedidosNegocio == null)
                throw new Exception("No implementado");
            return this.IPedidosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public pedidos Modificar(pedidos entidadModificada)
        {
            if (this.IPedidosNegocio == null)
                throw new Exception("No implementado");
            return this.IPedidosNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IPedidosNegocio!.Borrar(id);
                return Ok("pedido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
