

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class estadoReservaNegocio:IEstadoReservaNegocio
    {
        private IConexion? iConexion;

        public List<estadoReserva> Consultar(string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    usuario = usuario,
                    nombreTabla = "EstadoReserva",
                    accion = "Consultar",
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

        public estadoReserva Guardar(estadoReserva entidad, string usuario)
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
                throw new Exception("No se pudo guardar el estado de reserva");
            }
        }

        public estadoReserva Modificar(estadoReserva entidad, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<estadoReserva>(entidad!);
                entry.State = EntityState.Modified;
                var historicos = new historicos
                {
                    usuario= usuario,
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = "Modificar",
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

        public estadoReserva Borrar(estadoReserva estadoReserva, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                if (estadoReserva != null)
                {

                    this.iConexion.estadoReserva.Remove(estadoReserva);
                    var entry = this.iConexion!.Entry<estadoReserva>(estadoReserva!);

                    var historicos = new historicos
                    {
                        usuario = usuario,
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = "Borrar",
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
