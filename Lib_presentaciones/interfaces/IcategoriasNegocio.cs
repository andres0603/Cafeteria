using lib_cafeteria.modelos;

namespace Lib_presentaciones.interfaces
{
    public interface IcategoriasNegocio
    {
        List<categorias> Consultar(string usuario);
        categorias Guardar(categorias entidad, string usuario);
        categorias Modificar(categorias entidad, string usuario);
        categorias Borrar(categorias entidad, string usuario);
    }
}