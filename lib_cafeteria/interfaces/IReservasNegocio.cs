

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IReservasNegocio
    {
        List<reservas> Consultar();
        reservas Guardar(reservas entidad);
        reservas Modificar(reservas entidad);
        reservas Borrar(reservas entidad);

    }
}
