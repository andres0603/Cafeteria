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
        public List<pagos> Consultar(string usuario)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public pagos Guardar(pagos entidad, string usuario)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public pagos Modificar(pagos entidadModificada, string usuario)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public pagos Borrar(pagos entidad, string usuario)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Borrar(entidad, usuario);
        }
    }
}
