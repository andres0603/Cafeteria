
using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class TareasNegocio : ItareasNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<tareas> Consultar(string usuario)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/tareas/Consultar?usuario={usuario}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<tareas>();

            return JsonConvert.DeserializeObject<List<tareas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public tareas Guardar(tareas entidad, string usuario)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/tareas/Guardar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new tareas();

            return JsonConvert.DeserializeObject<tareas>(
                respuesta["Valor"].ToString()!)!;
        }

        public tareas Modificar(tareas entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/tareas/Modificar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new tareas();

            return JsonConvert.DeserializeObject<tareas>(
                respuesta["Valor"].ToString()!)!;
        }

        public tareas Borrar(tareas entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/tareas/Borrar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new tareas();

            return JsonConvert.DeserializeObject<tareas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
