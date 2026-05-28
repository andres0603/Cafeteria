

using lib_cafeteria.modelos;
using Lib_presentaciones.interfaces;
using Newtonsoft.Json;

namespace Lib_presentaciones.Implementaciones
{
    public class HistoricosNegocio : IhistoricosNegocio
    {
        private IComunicaciones? iComunicaciones;

        public List<historicos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5245/historicos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<historicos>();

            return JsonConvert.DeserializeObject<List<historicos>>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
