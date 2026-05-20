using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class proveedorController : ControllerBase
    {

        private IProveedoresNegocio? IProveedoresNegocio;

        public proveedorController()
        {
            this.IProveedoresNegocio = new proveedoresNegocio();
        }

        [HttpGet]
        public List<proveedores> Consultar()
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Consultar();
        }

        [HttpPost]
        public proveedores Guardar(proveedores entidad)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public proveedores Modificar(proveedores entidadModificada)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IProveedoresNegocio!.Borrar(id);
                return Ok("proveedor eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
