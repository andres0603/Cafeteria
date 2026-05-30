

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface ITareasNegocio
    {
        List<tareas> Consultar(string usuario);
        tareas Guardar(tareas entidad, string usuario);
        tareas Modificar(tareas entidad, string usuario);
        tareas Borrar(tareas entidad, string usuario);
    }
}
