

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IreservasNegocio
    {
        List<reservas> Consultar(string usuario);
        reservas Guardar(reservas entidad, string usuario);
        reservas Modificar(reservas entidad, string usuario);
        reservas Borrar(reservas entidad, string usuario);
    }
}
