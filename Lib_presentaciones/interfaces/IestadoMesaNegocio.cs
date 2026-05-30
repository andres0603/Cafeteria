

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IestadoMesaNegocio
    {
        List<estadosMesa> Consultar(string usuario);
        estadosMesa Guardar(estadosMesa entidad, string usuario);
        estadosMesa Modificar(estadosMesa entidad, string usuario);
        estadosMesa Borrar(estadosMesa entidad, string usuario);
    }
}
