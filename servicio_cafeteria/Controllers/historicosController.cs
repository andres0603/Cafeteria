using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class historicosController : ControllerBase
    {
        private IHistoricosNegocio? IHistoricosNegocio;

        public historicosController()
        {
            this.IHistoricosNegocio = new historicosNegocio();
        }

        [HttpGet]
        public List<historicos> Consultar()
        {
            if (this.IHistoricosNegocio == null)
                throw new Exception("No implementado");
            return this.IHistoricosNegocio!.Consultar();
        }

    }
}
