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
        public List<estadosPedido> Consultar(string usuario)
        {
            if (this.IEstadosPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosPedidoNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public estadosPedido Guardar(estadosPedido entidad, string usuario)
        {
            if (this.IEstadosPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosPedidoNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public estadosPedido Modificar(estadosPedido entidadModificada, string usuario)
        {
            if (this.IEstadosPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosPedidoNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public estadosPedido Borrar(estadosPedido entidad, string usuario)
        {
            if (this.IEstadosPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosPedidoNegocio!.Borrar(entidad, usuario);
        }
    }
}
