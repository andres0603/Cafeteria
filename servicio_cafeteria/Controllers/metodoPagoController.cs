using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class metodoPagoController : ControllerBase
    {
        
            private IMetodoPagoNegocio? IMetodoPagoNegocio;

            public metodoPagoController()
            {
                this.IMetodoPagoNegocio = new metodoPagoNegocio();
            }

            [HttpGet]
            public List<metodoPago> Consultar()
            {
                if (this.IMetodoPagoNegocio == null)
                    throw new Exception("No implementado");
                return this.IMetodoPagoNegocio!.Consultar();
            }

            [HttpPost]
            public metodoPago Guardar(metodoPago entidad)
            {
                if (this.IMetodoPagoNegocio == null)
                    throw new Exception("No implementado");
                return this.IMetodoPagoNegocio!.Guardar(entidad);
            }

            [HttpPut]
            public metodoPago Modificar(metodoPago entidadModificada)
            {
                if (this.IMetodoPagoNegocio == null)
                    throw new Exception("No implementado");
                return this.IMetodoPagoNegocio!.Modificar(entidadModificada);
            }

            [HttpDelete("{id}")]
            public IActionResult Borrar(int id)
            {
                try
                {
                    this.IMetodoPagoNegocio!.Borrar(id);
                    return Ok("Metodo de pago eliminado correctamente");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
}
