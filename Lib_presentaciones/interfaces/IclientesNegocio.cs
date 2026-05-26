

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IclientesNegocio
    {
        List<clientes> Consultar();
        clientes Guardar(clientes entidad);
        clientes Modificar(clientes entidad);
        clientes Borrar(clientes entidad);
    }
}
