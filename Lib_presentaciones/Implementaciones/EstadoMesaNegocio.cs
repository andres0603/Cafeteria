
using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class EstadoMesaNegocio : IestadoMesaNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<estadosMesa> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/estadosMesa/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<estadosMesa>();

            return JsonConvert.DeserializeObject<List<estadosMesa>>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadosMesa Guardar(estadosMesa entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/estadosMesa/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadosMesa();

            return JsonConvert.DeserializeObject<estadosMesa>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadosMesa Modificar(estadosMesa entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/estadosMesa/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadosMesa();

            return JsonConvert.DeserializeObject<estadosMesa>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadosMesa Borrar(estadosMesa entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/estadosMesa/Borrar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadosMesa();

            return JsonConvert.DeserializeObject<estadosMesa>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
