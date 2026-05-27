

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IPagosNegocio
    {
        List<pagos> Consultar();
        pagos Guardar(pagos entidad);
        pagos Modificar(pagos entidad);
        pagos Borrar(pagos entidad);
    }
}
