using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class sesionesController : ControllerBase
    {

        private ISesionesNegocio? ISesionesNegocio;

        public sesionesController()
        {
            this.ISesionesNegocio = new sesionesNegocio();
        }

        [HttpGet]
        public List<sesiones> Consultar()
        {
            if (this.ISesionesNegocio == null)
                throw new Exception("No implementado");
            return this.ISesionesNegocio!.Consultar();
        }

        [HttpPost]
        public sesiones Guardar(sesiones entidad)
        {
            if (this.ISesionesNegocio == null)
                throw new Exception("No implementado");
            return this.ISesionesNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public sesiones Modificar(sesiones entidadModificada)
        {
            if (this.ISesionesNegocio == null)
                throw new Exception("No implementado");
            return this.ISesionesNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete]
        public sesiones Borrar(sesiones entidad)
        {
            if (this.ISesionesNegocio == null)
                throw new Exception("No implementado");
            return this.ISesionesNegocio!.Borrar(entidad);
        }
    }
}
