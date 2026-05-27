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
        List<sedes> Consultar();
        sedes Guardar(sedes entidad);
        sedes Modificar(sedes entidad);
        sedes Borrar(sedes entidad);
        List<mesas> ObtenerMesasDisponibles(int personas);

    }
}
