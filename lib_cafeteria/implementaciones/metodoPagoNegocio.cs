

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class metodoPagoNegocio : IMetodoPagoNegocio
    {
        private IConexion? iConexion;

        public List<metodoPago> Consultar(string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    usuario = usuario,
                    nombreTabla = "MetodoPago",
                    accion = "Consultar",
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

        public metodoPago Guardar(metodoPago entidad, string usuario)
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
                throw new Exception("No se pudo guardar el metodo de pago");
            }
        }

        public metodoPago Modificar(metodoPago entidad, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<metodoPago>(entidad!);
                entry.State = EntityState.Modified;
                var historicos = new historicos
                {
                    usuario = usuario,
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = "Modificar",
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

        public metodoPago Borrar(metodoPago metodoPago, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");



                if (metodoPago != null)
                {

                    this.iConexion.metodoPago.Remove(metodoPago);
                    var entry = this.iConexion!.Entry<metodoPago>(metodoPago!);

                    var historicos = new historicos
                    {
                        usuario = usuario,
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = "Borrar",
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
