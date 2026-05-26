

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class MesasNegocio : ImesasNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<mesas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/mesas/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<mesas>();

            return JsonConvert.DeserializeObject<List<mesas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public mesas Guardar(mesas entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/mesas/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new mesas();

            return JsonConvert.DeserializeObject<mesas>(
                respuesta["Valor"].ToString()!)!;
        }

        public mesas Modificar(mesas entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/mesas/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new mesas();

            return JsonConvert.DeserializeObject<mesas>(
                respuesta["Valor"].ToString()!)!;
        }

        public mesas Borrar(mesas entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/mesas/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new mesas();

            return JsonConvert.DeserializeObject<mesas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
