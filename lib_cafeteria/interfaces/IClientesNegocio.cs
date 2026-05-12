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
        List<clientes> Consultar();
        clientes Guardar(clientes entidad);
        clientes Modificar(clientes entidad);
        clientes Borrar(int id);
        string consultarDescuento(int clienteId);
    }
}
