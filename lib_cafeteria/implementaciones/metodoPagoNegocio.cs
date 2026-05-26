

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class metodoPagoNegocio : IMetodoPagoNegocio
    {
        private IConexion? iConexion;

        public List<metodoPago> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "MetodoPago",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.metodoPago!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el metodo de pago");
            }
        }

        public metodoPago Guardar(metodoPago entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.metodoPago!.Add(entidad!);
                var entry = this.iConexion!.Entry<metodoPago>(entidad!);

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
                throw new Exception("No se pudo guardar el metodo de pago");
            }
        }

        public metodoPago Modificar(metodoPago entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<metodoPago>(entidad!);
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
                throw new Exception("No se pudo modificar el metodo de pago");
            }
            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public metodoPago Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var metodoPago = this.iConexion.metodoPago!.Find(id);

                if (metodoPago != null)
                {

                    this.iConexion.metodoPago.Remove(metodoPago);
                    var entry = this.iConexion!.Entry<metodoPago>(metodoPago!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return metodoPago;
                }

                throw new Exception("El metodo no existe");
            }
            catch
            {
                throw new Exception("No se pudo guardar el metodo de pago");
            }
        }
    }
}
