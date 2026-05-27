
using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IMesasNegocio
    {
        List<mesas> Consultar();
        mesas Guardar(mesas entidad);
        mesas Modificar(mesas entidad);
        mesas Borrar(mesas entidad);
    }
}
