
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IestadoReservaNegocio
    {
        List<estadoReserva> Consultar();
        estadoReserva Guardar(estadoReserva entidad);
        estadoReserva Modificar(estadoReserva entidad);
        estadoReserva Borrar(estadoReserva entidad);
    }
}
