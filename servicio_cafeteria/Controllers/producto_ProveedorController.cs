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
        public List<producto_proveedor> Consultar()
        {
            if (this.IProducto_proveedorNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_proveedorNegocio!.Consultar();
        }

        [HttpPost]
        public producto_proveedor Guardar(producto_proveedor entidad)
        {
            if (this.IProducto_proveedorNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_proveedorNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public producto_proveedor Modificar(producto_proveedor entidadModificada)
        {
            if (this.IProducto_proveedorNegocio == null)
                throw new Exception("No implementado");
            return this.IProducto_proveedorNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IProducto_proveedorNegocio!.Borrar(id);
                return Ok("producto por Proveedor eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
