using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IsesionesNegocio
    {
        List<sesiones> Consultar(string usuario);
        sesiones Guardar(sesiones entidad, string usuario);
        sesiones Modificar(sesiones entidad, string usuario);
        sesiones Borrar(sesiones entidad, string usuario);
    }
}
