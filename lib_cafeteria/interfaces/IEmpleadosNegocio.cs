
using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IEmpleadosNegocio
    {
        List<empleados> Consultar();
        empleados Guardar(empleados entidad);
        empleados Modificar(empleados entidad);
        empleados Borrar(int id);
    }
}
