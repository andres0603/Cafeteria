

using lib_cafeteria.modelos;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace lib_cafeteria.interfaces
{
    public interface IProveedoresNegocio
    {
        List<proveedores> Consultar(string usuario);
        proveedores Guardar(proveedores entidad, string usuario);
        proveedores Modificar(proveedores entidad, string usuario);
        proveedores Borrar(proveedores entidad, string usuario);
    }
}
