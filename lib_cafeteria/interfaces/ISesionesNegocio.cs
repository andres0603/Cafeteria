

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface ISesionesNegocio
    {
        List<sesiones> Consultar();
        sesiones Guardar(sesiones entidad);
        sesiones Modificar(sesiones entidad);
        sesiones Borrar(int id);
    }
}
