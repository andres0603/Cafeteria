using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IsesionesNegocio
    {
        List<sesiones> Consultar();
        sesiones Guardar(sesiones entidad);
        sesiones Modificar(sesiones entidad);
        sesiones Borrar(sesiones entidad);
    }
}
