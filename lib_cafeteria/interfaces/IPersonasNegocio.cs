
using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IPersonasNegocio
    {
        List<personas> Consultar(string usuario);
        personas Guardar(personas entidad, string usuario);
        personas Modificar(personas entidad, string usuario);
        personas Borrar(personas entidad, string usuario);
    }
}
