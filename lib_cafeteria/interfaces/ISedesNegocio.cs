using lib_cafeteria.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_cafeteria.interfaces
{
    public interface ISedesNegocio
    {
        List<sedes> Consultar(string usuario);
        sedes Guardar(sedes entidad, string usuario);
        sedes Modificar(sedes entidad, string usuario);
        sedes Borrar(sedes entidad, string usuario);
        List<mesas> ObtenerMesasDisponibles(int personas);

    }
}
