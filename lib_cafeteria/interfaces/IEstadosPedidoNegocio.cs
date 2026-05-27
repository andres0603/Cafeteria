using lib_cafeteria.modelos;


namespace lib_cafeteria.interfaces
{
    public interface IEstadosPedidoNegocio
    {
        List<estadosPedido> Consultar();
        estadosPedido Guardar(estadosPedido entidad);
        estadosPedido Modificar(estadosPedido entidad);
        estadosPedido Borrar(estadosPedido entidad);
    }
}
