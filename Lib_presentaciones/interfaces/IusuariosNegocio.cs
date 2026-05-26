using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IusuariosNegocio
    {
        List<usuarios> Consultar();
        usuarios Guardar(usuarios entidad);
        usuarios Modificar(usuarios entidad);
        usuarios Borrar(usuarios entidad);
    }
}
