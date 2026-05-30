

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IpedidosNegocio
    {
        List<pedidos> Consultar(string usuario);
        pedidos Guardar(pedidos entidad, string usuario);
        pedidos Modificar(pedidos entidad, string usuario);
        pedidos Borrar(pedidos entidad, string usuario);
    }
}
