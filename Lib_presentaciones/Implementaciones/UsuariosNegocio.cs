using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class UsuariosNegocio : IusuariosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<usuarios> Consultar(string usuario)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/usuarios/Consultar?usuario={usuario}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<usuarios>();

            return JsonConvert.DeserializeObject<List<usuarios>>(
                respuesta["Valor"].ToString()!)!;
        }

        public usuarios Guardar(usuarios entidad, string usuario)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/usuarios/Guardar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new usuarios();

            return JsonConvert.DeserializeObject<usuarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public usuarios Modificar(usuarios entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/usuarios/Modificar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new usuarios();

            return JsonConvert.DeserializeObject<usuarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public usuarios Borrar(usuarios entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/usuarios/Borrar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new usuarios();

            return JsonConvert.DeserializeObject<usuarios>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
