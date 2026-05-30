using lib_cafeteria.modelos;


namespace lib_cafeteria.interfaces
{
    public interface IRolesNegocio
    {
        List<roles> Consultar(string usuario);
        roles Guardar(roles entidad, string usuario);
        roles Modificar(roles entidad, string usuario);
        roles Borrar(roles entidad, string usuario);
        decimal calcularValorDia(int rolId);
    }
}
