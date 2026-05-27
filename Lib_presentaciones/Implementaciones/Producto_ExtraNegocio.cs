

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class Producto_ExtraNegocio : Iproducto_ExtraNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<producto_Extra> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/producto_Extra/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<producto_Extra>();

            return JsonConvert.DeserializeObject<List<producto_Extra>>(
                respuesta["Valor"].ToString()!)!;
        }

        public producto_Extra Guardar(producto_Extra entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/producto_Extra/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new producto_Extra();

            return JsonConvert.DeserializeObject<producto_Extra>(
                respuesta["Valor"].ToString()!)!;
        }

        public producto_Extra Modificar(producto_Extra entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/producto_Extra/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new producto_Extra();

            return JsonConvert.DeserializeObject<producto_Extra>(
                respuesta["Valor"].ToString()!)!;
        }

        public producto_Extra Borrar(producto_Extra entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/producto_Extra/Borrar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new producto_Extra();

            return JsonConvert.DeserializeObject<producto_Extra>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
