using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class productosController : ControllerBase
    {

        private IProductosNegocio? IProductosNegocio;

        public productosController()
        {
            this.IProductosNegocio = new productosNegocio();
        }

        [HttpGet]
        public List<productos> Consultar(string usuario)
        {
            if (this.IProductosNegocio == null)
                throw new Exception("No implementado");
            return this.IProductosNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public productos Guardar(productos entidad, string usuario)
        {
            if (this.IProductosNegocio == null)
                throw new Exception("No implementado");
            return this.IProductosNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public productos Modificar(productos entidadModificada, string usuario)
        {
            if (this.IProductosNegocio == null)
                throw new Exception("No implementado");
            return this.IProductosNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public productos Borrar(productos entidad, string usuario)
        {
            if (this.IProductosNegocio == null)
                throw new Exception("No implementado");
            return this.IProductosNegocio!.Borrar(entidad, usuario);
        }
    }
}
