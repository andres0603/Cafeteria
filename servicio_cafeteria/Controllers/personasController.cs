using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class personasController : ControllerBase
    {

        private IPersonasNegocio? IPersonasNegocio;

        public personasController()
        {
            this.IPersonasNegocio = new personasNegocio();
        }

        [HttpGet]
        public List<personas> Consultar()
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Consultar();
        }

        [HttpPost]
        public personas Guardar(personas entidad)
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public personas Modificar(personas entidadModificada)
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete]
        public personas Borrar(personas entidad)
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Borrar(entidad);
        }
    }
}
