

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class pagosNegocio : IPagosNegocio
    {
        private IConexion? iConexion;

        public List<pagos> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Pagos",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.pagos!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el pago");
            }
        }

        public pagos Guardar(pagos entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.pagos!.Add(entidad!);
                var entry = this.iConexion!.Entry<pagos>(entidad!);

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
                throw new Exception("No se pudo guardar el pago");
            }
        }

        public pagos Modificar(pagos entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<pagos>(entidad!);
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
                throw new Exception("No se pudo modificar el pago");
            }
            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public pagos Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var pago = this.iConexion.pagos!.Find(id);

                if (pago != null)
                {

                    this.iConexion.pagos.Remove(pago);
                    var entry = this.iConexion!.Entry<pagos>(pago!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return pago;
                }

                throw new Exception("El pago no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el pago");
            }
        }
    }
}
