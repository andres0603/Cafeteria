using lib_cafeteria.modelos;


namespace lib_cafeteria.interfaces
{
    public interface IdetallesPedidoNegocio
    {
        List<detallesPedido> Consultar(string usuario);
        detallesPedido Guardar(detallesPedido entidad, string usuario);
        detallesPedido Modificar(detallesPedido entidad, string usuario);
        detallesPedido Borrar(detallesPedido entidad, string usuario);
        decimal calcularSubTotal(int detalleId);
    }
}
