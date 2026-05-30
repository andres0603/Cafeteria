
using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IEmpleadosNegocio
    {
        List<empleados> Consultar(string usuario);
        empleados Guardar(empleados entidad, string usuario);
        empleados Modificar(empleados entidad, string usuario);
        empleados Borrar(empleados entidad, string usuario);
    }
}
