

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IdetallesPedidoNegocio
    {
        List<detallesPedido> Consultar(string usuario);
        detallesPedido Guardar(detallesPedido entidad, string usuario);
        detallesPedido Modificar(detallesPedido entidad, string usuario);
        detallesPedido Borrar(detallesPedido entidad, string usuario);
    }
}
