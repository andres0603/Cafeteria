

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class reservasNegocio : IReservasNegocio
    {
        private IConexion? iConexion;

        public List<reservas> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Reservas",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.reservas!
                    .Include(x=>x._estadoReserva)
                    .Include(x => x._clientes)
                    .ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar la reserva");
            }
        }

        public reservas Guardar(reservas entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.reservas!.Add(entidad!);
                var entry = this.iConexion!.Entry<reservas>(entidad!);

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
                throw new Exception("No se pudo guardar la reserva");
            }
        }

        public reservas Modificar(reservas entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<reservas>(entidad!);
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
                throw new Exception("No se pudo modificar la reserva");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public reservas Borrar(reservas reserva)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                if (reserva != null)
                {

                    this.iConexion.reservas.Remove(reserva);
                    var entry = this.iConexion!.Entry<reservas>(reserva!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return reserva;
                }

                throw new Exception("La reserva no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar la reserva");
            }
        }
    }
}
