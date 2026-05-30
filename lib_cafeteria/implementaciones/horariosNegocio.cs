
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class horariosNegocio : IHorariosNegocio
    {
        private IConexion? iConexion;

        public List<horarios> Consultar(string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    usuario = usuario,
                    nombreTabla = "Horarios",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.horarios!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el horario");
            }
        }

        public horarios Guardar(horarios entidad, string usuario)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.horarios!.Add(entidad!);
                var entry = this.iConexion!.Entry<horarios>(entidad!);

                var historicos = new historicos
                {
                    usuario = usuario,
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = "Guardar",
                    fechaCambio = DateTime.Now
                };

                this.iConexion.historicos!.Add(historicos);
                this.iConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                throw new Exception("No se pudo guardar el horario");
            }
        }

        public horarios Modificar(horarios entidad, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<horarios>(entidad!);
                entry.State = EntityState.Modified;
                var historicos = new historicos
                {
                    usuario=usuario,
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = "Modificar",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                this.iConexion!.SaveChanges();
            }
            catch
            {
                throw new Exception("No se pudo modificar el horario");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public horarios Borrar(horarios horario, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                if (horario != null)
                {

                    this.iConexion.horarios.Remove(horario);
                    var entry = this.iConexion!.Entry<horarios>(horario!);

                    var historicos = new historicos
                    {
                        usuario = usuario,
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = "Borrar",
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return horario;
                }

                throw new Exception("El horario no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el horario");
            }
        }
    }
}
