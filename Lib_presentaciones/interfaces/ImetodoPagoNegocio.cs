

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface ImetodoPagoNegocio
    {
        List<metodoPago> Consultar(string usuario);
        metodoPago Guardar(metodoPago entidad, string usuario);
        metodoPago Modificar(metodoPago entidad, string usuario);
        metodoPago Borrar(metodoPago entidad, string usuario);
    }
}
