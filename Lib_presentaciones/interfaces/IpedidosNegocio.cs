

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IpedidosNegocio
    {
        List<pedidos> Consultar();
        pedidos Guardar(pedidos entidad);
        pedidos Modificar(pedidos entidad);
        pedidos Borrar(pedidos entidad);
    }
}
