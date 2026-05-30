
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IproductosNegocio
    {
        List<productos> Consultar(string usuario);
        productos Guardar(productos entidad, string usuario);
        productos Modificar(productos entidad, string usuario);
        productos Borrar(productos entidad, string usuario);
    }
}
