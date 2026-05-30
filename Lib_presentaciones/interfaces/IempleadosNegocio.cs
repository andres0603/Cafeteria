

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IempleadosNegocio
    {
        List<empleados> Consultar(string usuario);
        empleados Guardar(empleados entidad, string usuario);
        empleados Modificar(empleados entidad, string usuario);
        empleados Borrar(empleados entidad, string usuario);
    }
}
