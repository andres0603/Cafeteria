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
        public List<producto_Extra> Consultar()
        {
            if (this.IProducto_ExtraNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_ExtraNegocio!.Consultar();
        }

        [HttpPost]
        public producto_Extra Guardar(producto_Extra entidad)
        {
            if (this.IProducto_ExtraNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_ExtraNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public producto_Extra Modificar(producto_Extra entidadModificada)
        {
            if (this.IProducto_ExtraNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_ExtraNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete]
        public producto_Extra Borrar(producto_Extra entidad)
        {
            if (this.IProducto_ExtraNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_ExtraNegocio!.Borrar(entidad);
        }
    }
}
