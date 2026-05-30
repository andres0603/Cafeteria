

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IMetodoPagoNegocio
    {
        List<metodoPago> Consultar(string usuario);
        metodoPago Guardar(metodoPago entidad, string usuario);
        metodoPago Modificar(metodoPago entidad, string usuario);
        metodoPago Borrar(metodoPago entidad, string usuario);
    }
}
