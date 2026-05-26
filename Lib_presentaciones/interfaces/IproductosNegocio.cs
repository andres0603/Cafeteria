
using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IproductosNegocio
    {
        List<productos> Consultar();
        productos Guardar(productos entidad);
        productos Modificar(productos entidad);
        productos Borrar(productos entidad);
    }
}
