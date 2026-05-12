using lib_cafeteria.modelos;


namespace lib_cafeteria.interfaces
{
    public interface IRolesNegocio
    {
        List<roles> Consultar();
        roles Guardar(roles entidad);
        roles Modificar(roles entidad);
        roles Borrar(int id);
        decimal calcularValorDia(int rolId);
    }
}
