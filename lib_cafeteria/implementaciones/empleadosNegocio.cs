

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class empleadosNegocio: IEmpleadosNegocio
    {
        private IConexion? iConexion;

        public List<empleados> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Empleados",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.empleados!
                    .Include(x=>x._horarios)
                    .Include(x=>x._rol)
                    .ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el empleado");
            }
        }

        public empleados Guardar(empleados entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.empleados!.Add(entidad!);
                var entry = this.iConexion!.Entry<empleados>(entidad!);

                var historicos = new historicos
                {
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = entry.State.ToString(),
                    fechaCambio = DateTime.Now
                };

                this.iConexion.historicos!.Add(historicos);
                this.iConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw new Exception("No se pudo guardar el empleado");
            }

        }

        public empleados Modificar(empleados entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<empleados>(entidad!);
                entry.State = EntityState.Modified;
                var historicos = new historicos
                {
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = entry.State.ToString(),
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                this.iConexion!.SaveChanges();
            }
            catch
            {
                throw new Exception("No se pudo modificar el empleado");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public empleados Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var empleados = this.iConexion.empleados!.Find(id);

                if (empleados != null)
                {

                    this.iConexion.empleados.Remove(empleados);
                    var entry = this.iConexion!.Entry<empleados>(empleados!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return empleados;
                }

                throw new Exception("El empleado no existe");
            }
            catch
            {
                throw new Exception("No se pudo guardar el empleado");
            }
        }
    }
}
