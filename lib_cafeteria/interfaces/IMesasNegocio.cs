
using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IMesasNegocio
    {
        List<mesas> Consultar(string usuario);
        mesas Guardar(mesas entidad, string usuario);
        mesas Modificar(mesas entidad, string usuario);
        mesas Borrar(mesas entidad, string usuario);
    }
}
