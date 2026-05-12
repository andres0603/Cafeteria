

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IEstadosMesaNegocio
    {
        List<estadosMesa> Consultar();
        estadosMesa Guardar(estadosMesa entidad);
        estadosMesa Modificar(estadosMesa entidad);
        estadosMesa Borrar(int id);
        string saberSiSePuedeAsignar(int id);
    }
}
