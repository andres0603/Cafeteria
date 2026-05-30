

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IProductosNegocio
    {
        List<productos> Consultar(string usuario);
        productos Guardar(productos entidad, string usuario);
        productos Modificar(productos entidad, string usuario);
        productos Borrar(productos entidad, string usuario);
    }
}
