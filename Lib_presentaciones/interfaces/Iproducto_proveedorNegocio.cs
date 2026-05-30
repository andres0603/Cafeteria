

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface Iproducto_proveedorNegocio
    {
        List<producto_proveedor> Consultar(string usuario);
        producto_proveedor Guardar(producto_proveedor entidad, string usuario);
        producto_proveedor Modificar(producto_proveedor entidad, string usuario);
        producto_proveedor Borrar(producto_proveedor entidad, string usuario);
    }
}
