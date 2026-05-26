
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IestadosPedidoNegocio
    {
        List<estadosPedido> Consultar();
        estadosPedido Guardar(estadosPedido entidad);
        estadosPedido Modificar(estadosPedido entidad);
        estadosPedido Borrar(estadosPedido entidad);
    }
}
