using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class reservasController : ControllerBase
    {

        private IReservasNegocio? IReservasNegocio;

        public reservasController()
        {
            this.IReservasNegocio = new reservasNegocio();
        }

        [HttpGet]
        public List<reservas> Consultar()
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Consultar();
        }

        [HttpPost]
        public reservas Guardar(reservas entidad)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public reservas Modificar(reservas entidadModificada)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete]
        public reservas Borrar(reservas entidad)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Borrar(entidad);
        }
    }
}
