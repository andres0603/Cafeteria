

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IempleadosNegocio
    {
        List<empleados> Consultar();
        empleados Guardar(empleados entidad);
        empleados Modificar(empleados entidad);
        empleados Borrar(empleados entidad);
    }
}
