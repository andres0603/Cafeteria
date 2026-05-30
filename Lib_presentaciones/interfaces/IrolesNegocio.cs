

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IrolesNegocio
    {
        List<roles> Consultar(string usuario);
        roles Guardar(roles entidad, string usuario);
        roles Modificar(roles entidad, string usuario);
        roles Borrar(roles entidad, string usuario);
    }
}
