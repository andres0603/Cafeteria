

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IProducto_ExtraNegocio
    {
        List<producto_Extra> Consultar();
        producto_Extra Guardar(producto_Extra entidad);
        producto_Extra Modificar(producto_Extra entidad);
        producto_Extra Borrar(int id);
    }
}
