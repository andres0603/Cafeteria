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
        public List<personas> Consultar(string usuario)
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public personas Guardar(personas entidad, string usuario)
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public personas Modificar(personas entidadModificada, string usuario)
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public personas Borrar(personas entidad, string usuario)
        {
            if (this.IPersonasNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonasNegocio!.Borrar(entidad, usuario);
        }
    }
}
