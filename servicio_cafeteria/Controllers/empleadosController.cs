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
        public List<empleados> Consultar(string usuario)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public empleados Guardar(empleados entidad, string usuario)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public empleados Modificar(empleados entidadModificada, string usuario)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public empleados Borrar(empleados entidad, string usuario)
        {
            if (this.IEmpleadosNegocio == null)
                throw new Exception("No implementado");
            return this.IEmpleadosNegocio!.Borrar(entidad, usuario);
        }
    }
}
