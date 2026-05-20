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
        public List<horarios> Consultar()
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio!.Consultar();
        }

        [HttpPost]
        public horarios Guardar(horarios entidad)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public horarios Modificar(horarios entidadModificada)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IHorariosNegocio!.Borrar(id);
                return Ok("Horario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
