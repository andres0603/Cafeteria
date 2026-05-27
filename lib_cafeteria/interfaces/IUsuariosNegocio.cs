

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IUsuariosNegocio
    {
        List<usuarios> Consultar();
        usuarios Guardar(usuarios entidad);
        usuarios Modificar(usuarios entidad);
        usuarios Borrar(usuarios entidad);

    }
}
