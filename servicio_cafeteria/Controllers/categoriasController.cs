using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class categoriasController : ControllerBase
    {

        private ICategoriasNegocio? ICategoriasNegocio;

        public categoriasController()
        {
            this.ICategoriasNegocio = new categoriasNegocio();
        }

        [HttpGet]
        public List<categorias> Consultar()
        {
            if (this.ICategoriasNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriasNegocio!.Consultar();
        }

        [HttpPost]
        public categorias Guardar(categorias entidad)
        {
            if (this.ICategoriasNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public categorias Modificar(categorias entidadModificada)
        {
            if (this.ICategoriasNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriasNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.ICategoriasNegocio!.Borrar(id);
                return Ok("Categoria eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
