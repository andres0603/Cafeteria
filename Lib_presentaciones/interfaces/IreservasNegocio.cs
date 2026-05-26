

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IreservasNegocio
    {
        List<reservas> Consultar();
        reservas Guardar(reservas entidad);
        reservas Modificar(reservas entidad);
        reservas Borrar(reservas entidad);
    }
}
