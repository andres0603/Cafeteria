
using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface ICategoriasNegocio
    {
        List<categorias> Consultar(string usuario);
        categorias Guardar(categorias entidad, string usuario);
        categorias Modificar(categorias entidad, string usuario);
        categorias Borrar(categorias entidad, string usuario);
    }
}
