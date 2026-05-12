using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class clientesController : ControllerBase
    {
        private IClientesNegocio? IClientesNegocio;

        public clientesController()
        {
            this.IClientesNegocio = new clientesNegocio();
        }

        [HttpGet]
        public List<clientes> Consultar()
        {
            if (this.IClientesNegocio == null)
                throw new Exception("No implementado");
            return this.IClientesNegocio!.Consultar();
        }

        [HttpPost]
        public clientes Guardar(clientes entidad)
        {
            if (this.IClientesNegocio == null)
                throw new Exception("No implementado");
            return this.IClientesNegocio!.Guardar(entidad, HttpContext);
        }

        [HttpPut]
        public clientes Modificar(clientes entidadModificada)
        {
            if (this.IClientesNegocio == null)
                throw new Exception("No implementado");
            return this.IClientesNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete("{id}")]
        public IActionResult Borrar(int id)
        {
            try
            {
                this.IClientesNegocio!.Borrar(id);
                return Ok("Arbol eliminado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{clienteId}")]
        public string consultarDescuento(int clienteId)
        {
            if (this.IClientesNegocio == null)
                throw new Exception("No implementado");
            return this.IClientesNegocio!.consultarDescuento(clienteId);

        }
    }
}
