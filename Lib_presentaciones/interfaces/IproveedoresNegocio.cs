

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IproveedoresNegocio
    {
        List<proveedores> Consultar(string usuario);
        proveedores Guardar(proveedores entidad, string usuario);
        proveedores Modificar(proveedores entidad, string usuario);
        proveedores Borrar(proveedores entidad, string usuario);
    }
}
