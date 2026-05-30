
using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class Producto_proveedorNegocio : Iproducto_proveedorNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<producto_proveedor> Consultar(string usuario)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/producto_proveedor/Consultar?usuario={usuario}";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<producto_proveedor>();

            return JsonConvert.DeserializeObject<List<producto_proveedor>>(
                respuesta["Valor"].ToString()!)!;
        }

        public producto_proveedor Guardar(producto_proveedor entidad, string usuario)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/producto_proveedor/Guardar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new producto_proveedor();

            return JsonConvert.DeserializeObject<producto_proveedor>(
                respuesta["Valor"].ToString()!)!;
        }

        public producto_proveedor Modificar(producto_proveedor entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/producto_proveedor/Modificar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new producto_proveedor();

            return JsonConvert.DeserializeObject<producto_proveedor>(
                respuesta["Valor"].ToString()!)!;
        }

        public producto_proveedor Borrar(producto_proveedor entidad, string usuario)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5245/producto_proveedor/Borrar?usuario={usuario}";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new producto_proveedor();

            return JsonConvert.DeserializeObject<producto_proveedor>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
