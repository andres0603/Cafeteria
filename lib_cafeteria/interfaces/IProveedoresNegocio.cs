

using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface IProveedoresNegocio
    {
        List<proveedores> Consultar();
        proveedores Guardar(proveedores entidad);
        proveedores Modificar(proveedores entidad);
        proveedores Borrar(int id);
    }
}
