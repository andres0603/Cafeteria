
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IestadoReservaNegocio
    {
        List<estadoReserva> Consultar(string usuario);
        estadoReserva Guardar(estadoReserva entidad, string usuario);
        estadoReserva Modificar(estadoReserva entidad, string usuario);
        estadoReserva Borrar(estadoReserva entidad, string usuario);
    }
}
