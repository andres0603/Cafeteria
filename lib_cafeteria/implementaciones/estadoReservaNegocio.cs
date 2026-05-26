

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class estadoReservaNegocio:IEstadoReservaNegocio
    {
        private IConexion? iConexion;

        public List<estadoReserva> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "EstadoReserva",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.estadoReserva!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el estado de reserva");
            }
        }

        public estadoReserva Guardar(estadoReserva entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.estadoReserva!.Add(entidad!);
                var entry = this.iConexion!.Entry<estadoReserva>(entidad!);

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
                throw new Exception("No se pudo guardar el estado de reserva");
            }
        }

        public estadoReserva Modificar(estadoReserva entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<estadoReserva>(entidad!);
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
                throw new Exception("No se pudo guardar el estado de reserva");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public estadoReserva Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var estadoReserva = this.iConexion.estadoReserva!.Find(id);

                if (estadoReserva != null)
                {

                    this.iConexion.estadoReserva.Remove(estadoReserva);
                    var entry = this.iConexion!.Entry<estadoReserva>(estadoReserva!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return estadoReserva;
                }

                throw new Exception("El estado no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el estado de reserva");
            }
        }
    }
}
