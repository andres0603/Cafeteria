
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface ItareasNegocio
    {
        List<tareas> Consultar(string usuario);
        tareas Guardar(tareas entidad, string usuario);
        tareas Modificar(tareas entidad, string usuario);
        tareas Borrar(tareas entidad, string usuario);
    }
}
