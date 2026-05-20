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

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.ISesionesNegocio!.Borrar(id);
                return Ok("Sesion eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
