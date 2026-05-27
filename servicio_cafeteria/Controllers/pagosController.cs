using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class pagosController : ControllerBase
    {

        private IPagosNegocio? IPagosNegocio;

        public pagosController()
        {
            this.IPagosNegocio = new pagosNegocio();
        }

        [HttpGet]
        public List<pagos> Consultar()
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Consultar();
        }

        [HttpPost]
        public pagos Guardar(pagos entidad)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public pagos Modificar(pagos entidadModificada)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete]
        public pagos Borrar(pagos entidad)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Borrar(entidad);
        }
    }
}
