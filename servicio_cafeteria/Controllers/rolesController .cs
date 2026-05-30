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
        public List<roles> Consultar(string usuario)
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public roles Guardar(roles entidad, string usuario)
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public roles Modificar(roles entidadModificada, string usuario)
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public roles Borrar(roles entidad, string usuario)
        {
            if (this.IRolesNegocio == null)
                throw new Exception("No implementado");
            return this.IRolesNegocio!.Borrar(entidad, usuario);
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
