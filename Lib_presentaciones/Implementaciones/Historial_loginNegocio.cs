

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class Historial_loginNegocio : Ihistorial_loginNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<historial_login> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/historial_login/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<historial_login>();

            return JsonConvert.DeserializeObject<List<historial_login>>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
