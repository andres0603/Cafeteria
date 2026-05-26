

using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IproveedoresNegocio
    {
        List<proveedores> Consultar();
        proveedores Guardar(proveedores entidad);
        proveedores Modificar(proveedores entidad);
        proveedores Borrar(proveedores entidad);
    }
}
