

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class pedidosNegocio : IPedidosNegocio
    {
        private IConexion? iConexion;

        public List<pedidos> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Pedidos",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.pedidos!
                    .Include(x=>x._clientes)
                    .Include(x=>x._estadosPedido)
                    .ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el pedido");
            }
        }

        public pedidos Guardar(pedidos entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.pedidos!.Add(entidad!);
                var entry = this.iConexion!.Entry<pedidos>(entidad!);

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
                throw new Exception("No se pudo guardar el pedido");
            }
        }

        public pedidos Modificar(pedidos entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<pedidos>(entidad!);
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
                throw new Exception("No se pudo modificar el pedido");
            }
            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public pedidos Borrar(pedidos pedido)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");



                if (pedido != null)
                {

                    this.iConexion.pedidos.Remove(pedido);
                    var entry = this.iConexion!.Entry<pedidos>(pedido!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return pedido;
                }

                throw new Exception("El pedido no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el pedido");
            }
        }
    }
}
