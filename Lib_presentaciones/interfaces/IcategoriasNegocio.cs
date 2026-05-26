using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IcategoriasNegocio
    {
        List<categorias> Consultar();
        categorias Guardar(categorias entidad);
        categorias Modificar(categorias entidad);
        categorias Borrar(categorias entidad);
    }
}