

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IsedesNegocio
    {
        List<sedes> Consultar();
        sedes Guardar(sedes entidad);
        sedes Modificar(sedes entidad);
        sedes Borrar(sedes entidad);
    }
}
