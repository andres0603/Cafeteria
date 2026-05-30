using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class producto_ExtraController : ControllerBase
    {

        private IProducto_ExtraNegocio? IProducto_ExtraNegocio;

        public producto_ExtraController()
        {
            this.IProducto_ExtraNegocio = new producto_ExtraNegocio();
        }

        [HttpGet]
        public List<producto_Extra> Consultar(string usuario)
        {
            if (this.IProducto_ExtraNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_ExtraNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public producto_Extra Guardar(producto_Extra entidad, string usuario)
        {
            if (this.IProducto_ExtraNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_ExtraNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public producto_Extra Modificar(producto_Extra entidadModificada, string usuario)
        {
            if (this.IProducto_ExtraNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_ExtraNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public producto_Extra Borrar(producto_Extra entidad, string usuario)
        {
            if (this.IProducto_ExtraNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_ExtraNegocio!.Borrar(entidad, usuario);
        }
    }
}
