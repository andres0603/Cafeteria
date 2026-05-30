using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class proveedoresController : ControllerBase
    {

        private IProveedoresNegocio? IProveedoresNegocio;

        public proveedoresController()
        {
            this.IProveedoresNegocio = new proveedoresNegocio();
        }

        [HttpGet]
        public List<proveedores> Consultar(string usuario)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public proveedores Guardar(proveedores entidad, string usuario)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public proveedores Modificar(proveedores entidadModificada, string usuario)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public proveedores Borrar(proveedores entidad, string usuario)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Borrar(entidad, usuario);
        }
    }
}
