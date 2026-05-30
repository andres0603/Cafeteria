

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IPedidosNegocio
    {
        List<pedidos> Consultar(string usuario);
        pedidos Guardar(pedidos entidad, string usuario);
        pedidos Modificar(pedidos entidad, string usuario);
        pedidos Borrar(pedidos entidad, string usuario);
    }
}
