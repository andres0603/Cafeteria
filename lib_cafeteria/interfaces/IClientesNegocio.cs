using lib_cafeteria.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_cafeteria.interfaces
{
    public interface IClientesNegocio
    {
        List<clientes> Consultar(string usuario);
        clientes Guardar(clientes entidad, string usuario);
        clientes Modificar(clientes entidad, string usuario);
        clientes Borrar(clientes entidad, string usuario);
        string consultarDescuento(int clienteId);
    }
}
