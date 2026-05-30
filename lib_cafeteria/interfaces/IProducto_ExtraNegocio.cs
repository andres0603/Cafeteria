

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IProducto_ExtraNegocio
    {
        List<producto_Extra> Consultar(string usuario);
        producto_Extra Guardar(producto_Extra entidad, string usuario);
        producto_Extra Modificar(producto_Extra entidad, string usuario);
        producto_Extra Borrar(producto_Extra entidad, string usuario);
    }
}
