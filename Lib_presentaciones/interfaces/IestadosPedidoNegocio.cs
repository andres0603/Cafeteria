
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IestadosPedidoNegocio
    {
        List<estadosPedido> Consultar(string usuario);
        estadosPedido Guardar(estadosPedido entidad, string usuario);
        estadosPedido Modificar(estadosPedido entidad, string usuario);
        estadosPedido Borrar(estadosPedido entidad, string usuario);
    }
}
