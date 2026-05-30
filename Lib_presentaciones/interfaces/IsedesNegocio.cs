

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IsedesNegocio
    {
        List<sedes> Consultar(string usuario);
        sedes Guardar(sedes entidad, string usuario);
        sedes Modificar(sedes entidad, string usuario);
        sedes Borrar(sedes entidad, string usuario);
    }
}
