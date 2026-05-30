using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class mesasController : ControllerBase
    {

        private IMesasNegocio? IMesasNegocio;

        public mesasController()
        {
            this.IMesasNegocio = new mesasNegocio();
        }

        [HttpGet]
        public List<mesas> Consultar(string usuario)
        {
            if (this.IMesasNegocio == null)
                throw new Exception("No implementado");
            return this.IMesasNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public mesas Guardar(mesas entidad, string usuario)
        {
            if (this.IMesasNegocio == null)
                throw new Exception("No implementado");
            return this.IMesasNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public mesas Modificar(mesas entidadModificada, string usuario)
        {
            if (this.IMesasNegocio == null)
                throw new Exception("No implementado");
            return this.IMesasNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public mesas Borrar(mesas entidad, string usuario)
        {
            if (this.IMesasNegocio == null)
                throw new Exception("No implementado");
            return this.IMesasNegocio!.Borrar(entidad, usuario);
        }
    }
}
