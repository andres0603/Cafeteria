

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface Iproducto_proveedorNegocio
    {
        List<producto_proveedor> Consultar();
        producto_proveedor Guardar(producto_proveedor entidad);
        producto_proveedor Modificar(producto_proveedor entidad);
        producto_proveedor Borrar(producto_proveedor entidad);
    }
}
