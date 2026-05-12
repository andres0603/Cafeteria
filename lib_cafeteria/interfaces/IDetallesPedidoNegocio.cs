using lib_cafeteria.modelos;


namespace lib_cafeteria.interfaces
{
    public interface IdetallesPedidoNegocio
    {
        List<detallesPedido> Consultar();
        detallesPedido Guardar(detallesPedido entidad);
        detallesPedido Modificar(detallesPedido entidad);
        detallesPedido Borrar(int id);
        decimal calcularSubTotal(int detalleId);
    }
}
