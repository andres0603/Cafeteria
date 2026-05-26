
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IpagosNegocio
    {
        List<pagos> Consultar();
        pagos Guardar(pagos entidad);
        pagos Modificar(pagos entidad);
        pagos Borrar(pagos entidad);
    }
}
