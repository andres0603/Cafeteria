
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;

namespace lib_cafeteria.implementaciones
{
    public class historicosNegocio : IHistoricosNegocio
    {
        private IConexion? iConexion;

        public List<historicos> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var lista = this.iConexion.historicos!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el historico");
            }
        }
    }
}
