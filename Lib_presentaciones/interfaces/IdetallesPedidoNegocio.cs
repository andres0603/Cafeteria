

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IdetallesPedidoNegocio
    {
        List<detallesPedido> Consultar();
        detallesPedido Guardar(detallesPedido entidad);
        detallesPedido Modificar(detallesPedido entidad);
        detallesPedido Borrar(detallesPedido entidad);
    }
}
