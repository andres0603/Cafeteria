

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface ISesionesNegocio
    {
        List<sesiones> Consultar(string usuario);
        sesiones Guardar(sesiones entidad, string usuario);
        sesiones Modificar(sesiones entidad, string usuario);
        sesiones Borrar(sesiones entidad, string usuario);
    }
}
