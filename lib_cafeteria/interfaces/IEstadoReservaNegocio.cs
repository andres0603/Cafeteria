using lib_cafeteria.modelos;


namespace lib_cafeteria.interfaces
{
    public interface IEstadoReservaNegocio
    {
        List<estadoReserva> Consultar();
        estadoReserva Guardar(estadoReserva entidad);
        estadoReserva Modificar(estadoReserva entidad);
        estadoReserva Borrar(estadoReserva entidad);
    }
}
