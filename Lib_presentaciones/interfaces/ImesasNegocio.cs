

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface ImesasNegocio
    {
        List<mesas> Consultar(string usuario);
        mesas Guardar(mesas entidad, string usuario);
        mesas Modificar(mesas entidad, string usuario);
        mesas Borrar(mesas entidad, string usuario);
    }
}
