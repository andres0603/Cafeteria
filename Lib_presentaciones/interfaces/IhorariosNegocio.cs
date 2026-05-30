
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IhorariosNegocio
    {
        List<horarios> Consultar(string usuario);
        horarios Guardar(horarios entidad, string usuario);
        horarios Modificar(horarios entidad, string usuario);
        horarios Borrar(horarios entidad, string usuario);
    }
}
