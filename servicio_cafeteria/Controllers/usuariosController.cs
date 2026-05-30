using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class usuariosController : ControllerBase
    {

        private IUsuariosNegocio? IUsuariosNegocio;

        public usuariosController()
        {
            this.IUsuariosNegocio = new usuariosNegocio();
        }

        [HttpGet]
        public List<usuarios> Consultar(string usuario)
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public usuarios Guardar(usuarios entidad, string usuario)
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public usuarios Modificar(usuarios entidadModificada, string usuario)
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public usuarios Borrar(usuarios entidad, string usuario)
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Borrar(entidad, usuario);
        }
    }
}
