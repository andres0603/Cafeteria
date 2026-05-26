

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class DetallesPedidoNegocio: IdetallesPedidoNegocio
    {

        private IComunicaciones? iComunicaciones;

        public List<detallesPedido> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/detallesPedido/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<detallesPedido>();

            return JsonConvert.DeserializeObject<List<detallesPedido>>(
                respuesta["Valor"].ToString()!)!;
        }

        public detallesPedido Guardar(detallesPedido entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/detallesPedido/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new detallesPedido();

            return JsonConvert.DeserializeObject<detallesPedido>(
                respuesta["Valor"].ToString()!)!;
        }

        public detallesPedido Modificar(detallesPedido entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/detallesPedido/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new detallesPedido();

            return JsonConvert.DeserializeObject<detallesPedido>(
                respuesta["Valor"].ToString()!)!;
        }

        public detallesPedido Borrar(detallesPedido entidad)
        {
            if (entidad.id == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/detallesPedido/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new detallesPedido();

            return JsonConvert.DeserializeObject<detallesPedido>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
