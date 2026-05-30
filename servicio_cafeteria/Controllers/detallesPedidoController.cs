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
        public List<detallesPedido> Consultar(string usuario)
        {
            if (this.IdetallesPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IdetallesPedidoNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public detallesPedido Guardar(detallesPedido entidad, string usuario)
        {
            if (this.IdetallesPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IdetallesPedidoNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public detallesPedido Modificar(detallesPedido entidadModificada, string usuario)
        {
            if (this.IdetallesPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IdetallesPedidoNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public detallesPedido Borrar(detallesPedido entidad, string usuario)
        {
            if (this.IdetallesPedidoNegocio == null)
                throw new Exception("No implementado");
            return this.IdetallesPedidoNegocio!.Borrar(entidad, usuario);
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
