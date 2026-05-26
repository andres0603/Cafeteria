

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface ImesasNegocio
    {
        List<mesas> Consultar();
        mesas Guardar(mesas entidad);
        mesas Modificar(mesas entidad);
        mesas Borrar(mesas entidad);
    }
}
