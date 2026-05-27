

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IPedidosNegocio
    {
        List<pedidos> Consultar();
        pedidos Guardar(pedidos entidad);
        pedidos Modificar(pedidos entidad);
        pedidos Borrar(pedidos entidad);
    }
}
