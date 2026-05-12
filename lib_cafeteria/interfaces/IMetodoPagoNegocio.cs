

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IMetodoPagoNegocio
    {
        List<mesas> Consultar();
        mesas Guardar(mesas entidad);
        mesas Modificar(mesas entidad);
        mesas Borrar(int id);
    }
}
