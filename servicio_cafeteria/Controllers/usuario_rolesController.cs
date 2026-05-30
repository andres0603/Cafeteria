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
        public List<usuario_roles> Consultar(string usuario)
        {
            if (this.IUsuario_rolesNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuario_rolesNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public usuario_roles Guardar(usuario_roles entidad, string usuario)
        {
            if (this.IUsuario_rolesNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuario_rolesNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public usuario_roles Modificar(usuario_roles entidadModificada, string usuario)
        {
            if (this.IUsuario_rolesNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuario_rolesNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public usuario_roles Borrar(usuario_roles entidad, string usuario)
        {
            if (this.IUsuario_rolesNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuario_rolesNegocio!.Borrar(entidad,usuario);
        }
    }
}
