

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface ITareasNegocio
    {
        List<tareas> Consultar();
        tareas Guardar(tareas entidad);
        tareas Modificar(tareas entidad);
        tareas Borrar(int id);
    }
}
