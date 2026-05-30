
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IpagosNegocio
    {
        List<pagos> Consultar(string usuario);
        pagos Guardar(pagos entidad, string usuario);
        pagos Modificar(pagos entidad, string usuario);
        pagos Borrar(pagos entidad, string usuario);
    }
}
