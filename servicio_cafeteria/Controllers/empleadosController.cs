using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class empleadosController : ControllerBase
    {

        private IEmpleadosNegocio? IEmpleadosNegocio;

        public empleadosController()
        {
            this.IEmpleadosNegocio = new empleadosNegocio();
        }

        [HttpGet]
        public List<empleados> Consultar()
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Consultar();
        }

        [HttpPost]
        public empleados Guardar(empleados entidad)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public empleados Modificar(empleados entidadModificada)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IEmpleadosNegocio!.Borrar(id);
                return Ok("Empleado eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
