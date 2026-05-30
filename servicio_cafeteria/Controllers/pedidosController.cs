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
        public List<pedidos> Consultar(string usuario)
        {
            if (this.IPedidosNegocio == null)
                throw new Exception("No implementado");
            return this.IPedidosNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public pedidos Guardar(pedidos entidad, string usuario)
        {
            if (this.IPedidosNegocio == null)
                throw new Exception("No implementado");
            return this.IPedidosNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public pedidos Modificar(pedidos entidadModificada, string usuario)
        {
            if (this.IPedidosNegocio == null)
                throw new Exception("No implementado");
            return this.IPedidosNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public pedidos Borrar(pedidos entidad, string usuario)
        {
            if (this.IPedidosNegocio == null)
                throw new Exception("No implementado");
            return this.IPedidosNegocio!.Borrar(entidad, usuario);
        }
    }
}
