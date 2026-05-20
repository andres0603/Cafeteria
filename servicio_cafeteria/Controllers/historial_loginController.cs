using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class historial_loginController : ControllerBase
    {

        private IHistorial_loginNegocio? IHistorial_loginNegocio;

        public historial_loginController()
        {
            this.IHistorial_loginNegocio = new historial_loginNegocio();
        }

        [HttpGet]
        public List<historial_login> Consultar()
        {
            if (this.IHistorial_loginNegocio == null)
                throw new Exception("No implementado");
            return this.IHistorial_loginNegocio!.Consultar();
        }
    }
}
