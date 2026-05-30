

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class EstadosPedidoNegocio : IestadosPedidoNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<estadosPedido> Consultar(string usuario)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/estadosPedido/Consultar?usuario={usuario}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<estadosPedido>();

            return JsonConvert.DeserializeObject<List<estadosPedido>>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadosPedido Guardar(estadosPedido entidad, string usuario)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/estadosPedido/Guardar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadosPedido();

            return JsonConvert.DeserializeObject<estadosPedido>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadosPedido Modificar(estadosPedido entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/estadosPedido/Modificar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadosPedido();

            return JsonConvert.DeserializeObject<estadosPedido>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadosPedido Borrar(estadosPedido entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/estadosPedido/Borrar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadosPedido();

            return JsonConvert.DeserializeObject<estadosPedido>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
