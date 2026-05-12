using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class rolesController : ControllerBase
    {
        private IRolesNegocio? IRolesNegocio;

        public rolesController()
        {
            this.IRolesNegocio = new rolesNegocio();
        }

        [HttpGet]
        public List<roles> Consultar()
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Consultar();
        }

        [HttpPost]
        public roles Guardar(roles entidad)
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public roles Modificar(roles entidadModificada)
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IRolesNegocio!.Borrar(id);
                return Ok("Rol eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{rolId}")]
        public decimal consultarDescuento(int rolId)
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.calcularValorDia(rolId);

        }
    }
}
