using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IHorariosNegocio
    {
        List<horarios> Consultar(string usuario);
        horarios Guardar(horarios entidad, string usuario);
        horarios Modificar(horarios entidad, string usuario);
        horarios Borrar(horarios entidad, string usuario);
    }
}
