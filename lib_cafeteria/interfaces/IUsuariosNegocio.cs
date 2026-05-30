

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IUsuariosNegocio
    {
        List<usuarios> Consultar(string usuario);
        usuarios Guardar(usuarios entidad, string usuario);
        usuarios Modificar(usuarios entidad, string usuario);
        usuarios Borrar(usuarios entidad, string usuario);

    }
}
