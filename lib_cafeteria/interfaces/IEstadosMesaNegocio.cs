

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IEstadosMesaNegocio
    {
        List<estadosMesa> Consultar(string usuario);
        estadosMesa Guardar(estadosMesa entidad, string usuario);
        estadosMesa Modificar(estadosMesa entidad, string usuario);
        estadosMesa Borrar(estadosMesa entidad, string usuario);
        string saberSiSePuedeAsignar(int id);
    }
}
