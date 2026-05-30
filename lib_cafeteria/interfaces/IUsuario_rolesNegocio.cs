

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IUsuario_rolesNegocio
    {
        List<usuario_roles> Consultar(string usuario);
        usuario_roles Guardar(usuario_roles entidad, string usuario);
        usuario_roles Modificar(usuario_roles entidad, string usuario);
        usuario_roles Borrar(usuario_roles entidad, string usuario);
    }
}
