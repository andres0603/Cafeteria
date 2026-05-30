using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class producto_ProveedorController : ControllerBase
    {
        
        private IProducto_proveedorNegocio? IProducto_proveedorNegocio;

        public producto_ProveedorController()
        {
            this.IProducto_proveedorNegocio = new producto_proveedorNegocio();
        }

        [HttpGet]
        public List<producto_proveedor> Consultar(string usuario)
        {
            if (this.IProducto_proveedorNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_proveedorNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public producto_proveedor Guardar(producto_proveedor entidad, string usuario)
        {
            if (this.IProducto_proveedorNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_proveedorNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public producto_proveedor Modificar(producto_proveedor entidadModificada, string usuario)
        {
            if (this.IProducto_proveedorNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_proveedorNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public producto_proveedor Borrar(producto_proveedor entidad, string usuario)
        {
            if (this.IProducto_proveedorNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_proveedorNegocio!.Borrar(entidad, usuario);
        }
    }
}
