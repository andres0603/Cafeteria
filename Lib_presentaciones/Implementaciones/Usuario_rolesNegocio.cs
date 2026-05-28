

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class Usuario_rolesNegocio : Iusuario_rolesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<usuario_roles> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/usuario_roles/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<usuario_roles>();

            return JsonConvert.DeserializeObject<List<usuario_roles>>(
                respuesta["Valor"].ToString()!)!;
        }

        public usuario_roles Guardar(usuario_roles entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/usuario_roles/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new usuario_roles();

            return JsonConvert.DeserializeObject<usuario_roles>(
                respuesta["Valor"].ToString()!)!;
        }

        public usuario_roles Modificar(usuario_roles entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/usuario_roles/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new usuario_roles();

            return JsonConvert.DeserializeObject<usuario_roles>(
                respuesta["Valor"].ToString()!)!;
        }

        public usuario_roles Borrar(usuario_roles entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/usuario_roles/Borrar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new usuario_roles();

            return JsonConvert.DeserializeObject<usuario_roles>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
