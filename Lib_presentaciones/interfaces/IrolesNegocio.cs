

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IrolesNegocio
    {
        List<roles> Consultar();
        roles Guardar(roles entidad);
        roles Modificar(roles entidad);
        roles Borrar(roles entidad);
    }
}
