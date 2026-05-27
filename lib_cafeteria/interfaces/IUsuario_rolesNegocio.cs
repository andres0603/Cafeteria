

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IUsuario_rolesNegocio
    {
        List<usuario_roles> Consultar();
        usuario_roles Guardar(usuario_roles entidad);
        usuario_roles Modificar(usuario_roles entidad);
        usuario_roles Borrar(usuario_roles entidad);
    }
}
