

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IPagosNegocio
    {
        List<pagos> Consultar(string usuario);
        pagos Guardar(pagos entidad, string usuario);
        pagos Modificar(pagos entidad, string usuario);
        pagos Borrar(pagos entidad, string usuario);
    }
}
