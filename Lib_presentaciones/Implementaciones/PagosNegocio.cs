

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class PagosNegocio : IpagosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<pagos> Consultar(string usuario)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/pagos/Consultar?usuario={usuario}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<pagos>();

            return JsonConvert.DeserializeObject<List<pagos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public pagos Guardar(pagos entidad, string usuario)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/pagos/Guardar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new pagos();

            return JsonConvert.DeserializeObject<pagos>(
                respuesta["Valor"].ToString()!)!;
        }

        public pagos Modificar(pagos entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/pagos/Modificar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new pagos();

            return JsonConvert.DeserializeObject<pagos>(
                respuesta["Valor"].ToString()!)!;
        }

        public pagos Borrar(pagos entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/pagos/Borrar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new pagos();

            return JsonConvert.DeserializeObject<pagos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
