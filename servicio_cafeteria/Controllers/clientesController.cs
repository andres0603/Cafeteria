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
            return this.IClientesNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public clientes Modificar(clientes entidadModificada)
        {
            if (this.IClientesNegocio == null)
                throw new Exception("No implementado");
            return this.IClientesNegocio!.Modificar(entidadModificada);
        }

        [HttpDelete]
        public clientes Borrar(clientes entidad)
        {
            try
            {
                this.IClientesNegocio!.Borrar(entidad);
                return entidad;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar");
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
