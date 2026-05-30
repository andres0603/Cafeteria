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
            public List<metodoPago> Consultar(string usuario)
            {
                if (this.IMetodoPagoNegocio == null)
                    throw new Exception("No implementado");
                return this.IMetodoPagoNegocio!.Consultar(usuario);
            }

            [HttpPost]
            public metodoPago Guardar(metodoPago entidad,string usuario)
            {
                if (this.IMetodoPagoNegocio == null)
                    throw new Exception("No implementado");
                return this.IMetodoPagoNegocio!.Guardar(entidad, usuario);
            }

            [HttpPut]
            public metodoPago Modificar(metodoPago entidadModificada, string usuario)
            {
                if (this.IMetodoPagoNegocio == null)
                    throw new Exception("No implementado");
                return this.IMetodoPagoNegocio!.Modificar(entidadModificada, usuario);
            }

        [HttpDelete]
        public metodoPago Borrar(metodoPago entidad, string usuario)
        {
            if (this.IMetodoPagoNegocio == null)
                throw new Exception("No implementado");
            return this.IMetodoPagoNegocio!.Borrar(entidad, usuario);
        }
        }
}
