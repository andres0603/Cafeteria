

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IclientesNegocio
    {
        List<clientes> Consultar(string usuario);
        clientes Guardar(clientes entidad, string usuario);
        clientes Modificar(clientes entidad, string usuario);
        clientes Borrar(clientes entidad, string usuario);
    }
}
