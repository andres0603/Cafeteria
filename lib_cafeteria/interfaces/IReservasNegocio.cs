

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IReservasNegocio
    {
        List<reservas> Consultar(string usuario);
        reservas Guardar(reservas entidad, string usuario);
        reservas Modificar(reservas entidad, string usuario);
        reservas Borrar(reservas entidad, string usuario);

    }
}
