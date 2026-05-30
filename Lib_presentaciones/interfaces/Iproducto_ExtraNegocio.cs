

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface Iproducto_ExtraNegocio
    {
        List<producto_Extra> Consultar(string usuario);
        producto_Extra Guardar(producto_Extra entidad, string usuario);
        producto_Extra Modificar(producto_Extra entidad, string usuario);
        producto_Extra Borrar(producto_Extra entidad, string usuario);
    }
}
