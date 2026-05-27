

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;


namespace lib_cafeteria.implementaciones
{
    public class sedesNegocio : ISedesNegocio
    {
        private IConexion? iConexion;

        public List<sedes> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Sedes",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.sedes!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar la sede");
            }
        }

        public sedes Guardar(sedes entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.sedes!.Add(entidad!);
                var entry = this.iConexion!.Entry<sedes>(entidad!);

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
                throw new Exception("No se pudo guardar la sede");
            }
        }

        public sedes Modificar(sedes entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<sedes>(entidad!);
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
                throw new Exception("No se pudo modificar la sede");
            }
            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public sedes Borrar(sedes sede)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


             

                if (sede != null)
                {

                    this.iConexion.sedes.Remove(sede);
                    var entry = this.iConexion!.Entry<sedes>(sede!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return sede;
                }

                throw new Exception("La sede no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar la sede");
            }
        }
        public List<mesas> ObtenerMesasDisponibles(int personas)
        {

            this.iConexion  = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            return iConexion?.mesas?.Where(m => m.activo &&
                                     m.estadoMesa == 1 &&
                                     m.capacidad >= personas)
                         .OrderBy(m => m.capacidad)
                         .ToList() ?? new List<mesas>();
        }
    }
}
