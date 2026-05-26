

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface Iproducto_ExtraNegocio
    {
        List<producto_Extra> Consultar();
        producto_Extra Guardar(producto_Extra entidad);
        producto_Extra Modificar(producto_Extra entidad);
        producto_Extra Borrar(producto_Extra entidad);
    }
}
