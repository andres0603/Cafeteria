using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class sedesController : ControllerBase
    {
        private ISedesNegocio? ISedesNegocio;

        public sedesController()
        {
            this.ISedesNegocio = new sedesNegocio();
        }

        [HttpGet]
        public List<sedes> Consultar()
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.Consultar();
        }

        [HttpPost]
        public sedes Guardar(sedes entidad)
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public sedes Modificar(sedes entidadModificada)
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.ISedesNegocio!.Borrar(id);
                return Ok("Sede eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public List<mesas> ObtenerMesasDisponibles(int personas)
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.ObtenerMesasDisponibles(personas);

        }
    }
}
