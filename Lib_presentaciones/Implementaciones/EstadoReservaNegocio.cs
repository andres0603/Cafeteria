

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class EstadoReservaNegocio : IestadoReservaNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<estadoReserva> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/estadoReserva/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<estadoReserva>();

            return JsonConvert.DeserializeObject<List<estadoReserva>>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadoReserva Guardar(estadoReserva entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/estadoReserva/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadoReserva();

            return JsonConvert.DeserializeObject<estadoReserva>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadoReserva Modificar(estadoReserva entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/estadoReserva/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadoReserva();

            return JsonConvert.DeserializeObject<estadoReserva>(
                respuesta["Valor"].ToString()!)!;
        }

        public estadoReserva Borrar(estadoReserva entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/estadoReserva/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new estadoReserva();

            return JsonConvert.DeserializeObject<estadoReserva>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
