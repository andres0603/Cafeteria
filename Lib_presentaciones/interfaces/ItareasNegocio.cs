
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface ItareasNegocio
    {
        List<tareas> Consultar();
        tareas Guardar(tareas entidad);
        tareas Modificar(tareas entidad);
        tareas Borrar(tareas entidad);
    }
}
