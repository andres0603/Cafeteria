

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface ImetodoPagoNegocio
    {
        List<metodoPago> Consultar();
        metodoPago Guardar(metodoPago entidad);
        metodoPago Modificar(metodoPago entidad);
        metodoPago Borrar(metodoPago entidad);
    }
}
