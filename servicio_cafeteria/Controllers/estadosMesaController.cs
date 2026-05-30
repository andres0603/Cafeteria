using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.AspNetCore.Mvc;

namespace servicio_cafeteria.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class estadosMesaController : ControllerBase
    {
        private IEstadosMesaNegocio? IEstadosMesaNegocio;

        public estadosMesaController()
        {
            this.IEstadosMesaNegocio = new estadosMesaNegocio();
        }

        [HttpGet]
        public List<estadosMesa> Consultar(string usuario)
        {
            if (this.IEstadosMesaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosMesaNegocio!.Consultar(usuario);
        }

        [HttpPost]
        public estadosMesa Guardar(estadosMesa entidad, string usuario)
        {
            if (this.IEstadosMesaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosMesaNegocio!.Guardar(entidad, usuario);
        }

        [HttpPut]
        public estadosMesa Modificar(estadosMesa entidadModificada, string usuario)
        {
            if (this.IEstadosMesaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosMesaNegocio!.Modificar(entidadModificada, usuario);
        }

        [HttpDelete]
        public estadosMesa Borrar(estadosMesa entidad, string usuario)
        {
            if (this.IEstadosMesaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosMesaNegocio!.Borrar(entidad, usuario);
        }

        [HttpGet("{id}")]
        public string saberSiSePuedeAsignar(int id)
        {
            if (this.IEstadosMesaNegocio == null)
                throw new Exception("No implementado");
            return this.IEstadosMesaNegocio!.saberSiSePuedeAsignar(id);

        }
    }
}
