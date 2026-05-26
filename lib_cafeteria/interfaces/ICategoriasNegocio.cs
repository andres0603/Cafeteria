
using lib_cafeteria.modelos;

namespace lib_cafeteria.interfaces
{
    public interface ICategoriasNegocio
    {
        List<categorias> Consultar();
        categorias Guardar(categorias entidad);
        categorias Modificar(categorias entidad);
        categorias Borrar(categorias entidad);
    }
}
