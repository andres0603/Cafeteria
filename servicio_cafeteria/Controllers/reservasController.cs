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
        public List<reservas> Consultar(string usuario)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public reservas Guardar(reservas entidad, string usuario)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public reservas Modificar(reservas entidadModificada, string usuario)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public reservas Borrar(reservas entidad, string usuario)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Borrar(entidad, usuario);
        }
    }
}
