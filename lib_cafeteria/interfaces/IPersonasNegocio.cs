
using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IPersonasNegocio
    {
        List<personas> Consultar();
        personas Guardar(personas entidad);
        personas Modificar(personas entidad);
        personas Borrar(personas entidad);
    }
}
