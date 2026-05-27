

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IProductosNegocio
    {
        List<productos> Consultar();
        productos Guardar(productos entidad);
        productos Modificar(productos entidad);
        productos Borrar(productos entidad);
    }
}
