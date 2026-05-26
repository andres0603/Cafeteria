
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IhorariosNegocio
    {
        List<horarios> Consultar();
        horarios Guardar(horarios entidad);
        horarios Modificar(horarios entidad);
        horarios Borrar(horarios entidad);
    }
}
