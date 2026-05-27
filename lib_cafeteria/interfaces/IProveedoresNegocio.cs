

using lib_cafeteria.modelos;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace lib_cafeteria.interfaces
{
    public interface IProveedoresNegocio
    {
        List<proveedores> Consultar();
        proveedores Guardar(proveedores entidad);
        proveedores Modificar(proveedores entidad);
        proveedores Borrar(proveedores entidad);
    }
}
