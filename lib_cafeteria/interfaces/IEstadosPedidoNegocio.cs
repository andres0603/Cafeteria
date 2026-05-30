using lib_cafeteria.modelos;


namespace lib_cafeteria.interfaces
{
    public interface IEstadosPedidoNegocio
    {
        List<estadosPedido> Consultar(string usuario);
        estadosPedido Guardar(estadosPedido entidad, string usuario);
        estadosPedido Modificar(estadosPedido entidad, string usuario);
        estadosPedido Borrar(estadosPedido entidad, string usuario);
    }
}
