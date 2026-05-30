using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class horariosController : ControllerBase
    {

        private IHorariosNegocio? IHorariosNegocio;

        public horariosController()
        {
            this.IHorariosNegocio = new horariosNegocio();
        }

        [HttpGet]
        public List<horarios> Consultar(string usuario)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public horarios Guardar(horarios entidad, string usuario)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public horarios Modificar(horarios entidadModificada, string usuario)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public horarios Borrar(horarios entidad, string usuario)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio!.Borrar(entidad, usuario);
        }
    }
}
