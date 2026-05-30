
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface Iusuario_rolesNegocio
    {
        List<usuario_roles> Consultar(string usuario);
        usuario_roles Guardar(usuario_roles entidad, string usuario);
        usuario_roles Modificar(usuario_roles entidad, string usuario);
        usuario_roles Borrar(usuario_roles entidad, string usuario);
    }
}
