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
        public List<usuarios> Consultar()
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Consultar();
        }

        [HttpPost]
        public usuarios Guardar(usuarios entidad)
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public usuarios Modificar(usuarios entidadModificada)
        {
            if (this.IUsuariosNegocio == null)
                throw new Exception("No implementado");
            return this.IUsuariosNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IUsuariosNegocio!.Borrar(id);
                return Ok("usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
