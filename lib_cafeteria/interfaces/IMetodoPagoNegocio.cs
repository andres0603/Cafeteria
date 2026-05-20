

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IMetodoPagoNegocio
    {
        List<metodoPago> Consultar();
        metodoPago Guardar(metodoPago entidad);
        metodoPago Modificar(metodoPago entidad);
        metodoPago Borrar(int id);
    }
}
