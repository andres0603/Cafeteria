using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class tareasController : ControllerBase
    {

        private ITareasNegocio? ITareasNegocio;

        public tareasController()
        {
            this.ITareasNegocio = new tareasNegocio();
        }

        [HttpGet]
        public List<tareas> Consultar()
        {
            if (this.ITareasNegocio == null)
                throw new Exception("No implementado");
            return this.ITareasNegocio!.Consultar();
        }

        [HttpPost]
        public tareas Guardar(tareas entidad)
        {
            if (this.ITareasNegocio == null)
                throw new Exception("No implementado");
            return this.ITareasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public tareas Modificar(tareas entidadModificada)
        {
            if (this.ITareasNegocio == null)
                throw new Exception("No implementado");
            return this.ITareasNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.ITareasNegocio!.Borrar(id);
                return Ok("tarea eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
