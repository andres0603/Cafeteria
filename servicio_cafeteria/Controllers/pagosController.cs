using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class pagosController : ControllerBase
    {

        private IPagosNegocio? IPagosNegocio;

        public pagosController()
        {
            this.IPagosNegocio = new pagosNegocio();
        }

        [HttpGet]
        public List<pagos> Consultar()
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Consultar();
        }

        [HttpPost]
        public pagos Guardar(pagos entidad)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public pagos Modificar(pagos entidadModificada)
        {
            if (this.IPagosNegocio == null)
                throw new Exception("No implementado");
            return this.IPagosNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IPagosNegocio!.Borrar(id);
                return Ok("pago eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
