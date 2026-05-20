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
        public List<mesas> Consultar()
        {
            if (this.IMesasNegocio == null)
                throw new Exception("No implementado");
            return this.IMesasNegocio!.Consultar();
        }

        [HttpPost]
        public mesas Guardar(mesas entidad)
        {
            if (this.IMesasNegocio == null)
                throw new Exception("No implementado");
            return this.IMesasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public mesas Modificar(mesas entidadModificada)
        {
            if (this.IMesasNegocio == null)
                throw new Exception("No implementado");
            return this.IMesasNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IMesasNegocio!.Borrar(id);
                return Ok("Mesa eliminada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
