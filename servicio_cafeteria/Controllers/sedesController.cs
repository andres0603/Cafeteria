using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class sedesController : ControllerBase
    {
        private ISedesNegocio? ISedesNegocio;

        public sedesController()
        {
            this.ISedesNegocio = new sedesNegocio();
        }

        [HttpGet]
        public List<sedes> Consultar(string usuario)
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public sedes Guardar(sedes entidad, string usuario)
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public sedes Modificar(sedes entidadModificada, string usuario)
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public sedes Borrar(sedes entidad, string usuario)
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.Borrar(entidad, usuario);
        }

        [HttpGet]
        public List<mesas> ObtenerMesasDisponibles(int personas)
        {
            if (this.ISedesNegocio == null)
                throw new Exception("No implementado");
            return this.ISedesNegocio!.ObtenerMesasDisponibles(personas);

        }
    }
}
