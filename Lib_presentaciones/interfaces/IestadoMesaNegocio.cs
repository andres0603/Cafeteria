

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IestadosMesaNegocio
    {
        List<estadosMesa> Consultar();
        estadosMesa Guardar(estadosMesa entidad);
        estadosMesa Modificar(estadosMesa entidad);
        estadosMesa Borrar(estadosMesa entidad);
    }
}
