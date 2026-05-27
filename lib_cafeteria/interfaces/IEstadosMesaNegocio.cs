

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IEstadosMesaNegocio
    {
        List<estadosMesa> Consultar();
        estadosMesa Guardar(estadosMesa entidad);
        estadosMesa Modificar(estadosMesa entidad);
        estadosMesa Borrar(estadosMesa entidad);
        string saberSiSePuedeAsignar(int id);
    }
}
