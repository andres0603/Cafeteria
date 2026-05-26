

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class ProductosNegocio : IproductosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<productos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/productos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<productos>();

            return JsonConvert.DeserializeObject<List<productos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public productos Guardar(productos entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/productos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new productos();

            return JsonConvert.DeserializeObject<productos>(
                respuesta["Valor"].ToString()!)!;
        }

        public productos Modificar(productos entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/productos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new productos();

            return JsonConvert.DeserializeObject<productos>(
                respuesta["Valor"].ToString()!)!;
        }

        public productos Borrar(productos entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/productos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new productos();

            return JsonConvert.DeserializeObject<productos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
