using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IusuariosNegocio
    {
        List<usuarios> Consultar(string usuario);
        usuarios Guardar(usuarios entidad, string usuario);
        usuarios Modificar(usuarios entidad, string usuario);
        usuarios Borrar(usuarios entidad, string usuario);
    }
}
