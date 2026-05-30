

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IProducto_proveedorNegocio
    {
        List<producto_proveedor> Consultar(string usuario);
        producto_proveedor Guardar(producto_proveedor entidad, string usuario);
        producto_proveedor Modificar(producto_proveedor entidad, string usuario);
        producto_proveedor Borrar(producto_proveedor entidad, string usuario);
    }
}
