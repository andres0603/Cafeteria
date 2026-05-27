using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IHorariosNegocio
    {
        List<horarios> Consultar();
        horarios Guardar(horarios entidad);
        horarios Modificar(horarios entidad);
        horarios Borrar(horarios entidad);
    }
}
