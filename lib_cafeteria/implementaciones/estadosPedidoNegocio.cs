

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class estadosPedidoNegocio: IEstadosPedidoNegocio
    {
        private IConexion? iConexion;

        public List<estadosPedido> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "EstadosPedido",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.estadosPedido!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el estado del pedido");
            }
        }

        public estadosPedido Guardar(estadosPedido entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.estadosPedido!.Add(entidad!);
                var entry = this.iConexion!.Entry<estadosPedido>(entidad!);

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
                throw new Exception("No se pudo guardar el estado del pedido");
            }
        }

        public estadosPedido Modificar(estadosPedido entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<estadosPedido>(entidad!);
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
                throw new Exception("No se pudo modificar el estado del pedido");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public estadosPedido Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var estadosPedido = this.iConexion.estadosPedido!.Find(id);

                if (estadosPedido != null)
                {

                    this.iConexion.estadosPedido.Remove(estadosPedido);
                    var entry = this.iConexion!.Entry<estadosPedido>(estadosPedido!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return estadosPedido;

                }

                throw new Exception("El estado no existe");
            }

            catch
            {
                throw new Exception("No se pudo borrar el estado del pedido");
            }
        }
    }
}
