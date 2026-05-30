using lib_cafeteria.modelos;


namespace lib_cafeteria.interfaces
{
    public interface IEstadoReservaNegocio
    {
        List<estadoReserva> Consultar(string usuario);
        estadoReserva Guardar(estadoReserva entidad, string usuario);
        estadoReserva Modificar(estadoReserva entidad, string usuario);
        estadoReserva Borrar(estadoReserva entidad, string usuario);
    }
}
