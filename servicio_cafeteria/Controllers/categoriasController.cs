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

        [HttpDelete]
        public categorias Borrar(categorias entidad)
        {
            try
            {
                this.ICategoriasNegocio!.Borrar(entidad!);
                return entidad;
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido eliminar");
            }
        }
    }
}
