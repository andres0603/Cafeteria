using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class usuario_rolesController : ControllerBase
    {

        private IUsuario_rolesNegocio? IUsuario_rolesNegocio;

        public usuario_rolesController()
        {
            this.IUsuario_rolesNegocio = new usuario_rolesNegocio();
        }

        [HttpGet]
        public List<usuario_roles> Consultar()
        {
            if (this.IUsuario_rolesNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuario_rolesNegocio!.Consultar();
        }

        [HttpPost]
        public usuario_roles Guardar(usuario_roles entidad)
        {
            if (this.IUsuario_rolesNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuario_rolesNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public usuario_roles Modificar(usuario_roles entidadModificada)
        {
            if (this.IUsuario_rolesNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuario_rolesNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IUsuario_rolesNegocio!.Borrar(id);
                return Ok("Uusario por rol eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
