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
        public List<productos> Consultar()
        {
            if (this.IProductosNegocio == null)
                throw new Exception("No implementado");
            return this.IProductosNegocio!.Consultar();
        }

        [HttpPost]
        public productos Guardar(productos entidad)
        {
            if (this.IProductosNegocio == null)
                throw new Exception("No implementado");
            return this.IProductosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public productos Modificar(productos entidadModificada)
        {
            if (this.IProductosNegocio == null)
                throw new Exception("No implementado");
            return this.IProductosNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete]
        public productos Borrar(productos entidad)
        {
            if (this.IProductosNegocio == null)
                throw new Exception("No implementado");
            return this.IProductosNegocio!.Borrar(entidad);
        }
    }
}
