

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class ClientesNegocio : IclientesNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<clientes> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/clientes/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<clientes>();

            return JsonConvert.DeserializeObject<List<clientes>>(
                respuesta["Valor"].ToString()!)!;
        }

        public clientes Guardar(clientes entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/clientes/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new clientes();

            return JsonConvert.DeserializeObject<clientes>(
                respuesta["Valor"].ToString()!)!;
        }

        public clientes Modificar(clientes entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/clientes/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new clientes();

            return JsonConvert.DeserializeObject<clientes>(
                respuesta["Valor"].ToString()!)!;
        }

        public clientes Borrar(clientes entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/clientes/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new clientes();

            return JsonConvert.DeserializeObject<clientes>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}

