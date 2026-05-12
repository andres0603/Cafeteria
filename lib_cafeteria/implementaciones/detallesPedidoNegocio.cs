using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class detallesPedidoNegocio: IdetallesPedidoNegocio
    {
        private IConexion? iConexion;

        public List<detallesPedido> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var lista = this.iConexion.detallesPedido!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el detalle del pedido");
            }
        }

        public detallesPedido Guardar(detallesPedido entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.detallesPedido!.Add(entidad!);
                var entry = this.iConexion!.Entry<detallesPedido>(entidad!);

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
                throw new Exception("No se pudo guardar el detalle del pedido");
            }
        }

        public detallesPedido Modificar(detallesPedido entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<detallesPedido>(entidad!);
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
                throw new Exception("No se pudo modificar el detalle del pedido");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public detallesPedido Borrar(int id)
        {
            try {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var detallePedido = this.iConexion.detallesPedido!.Find(id);

                if (detallePedido != null)
                {

                    this.iConexion.detallesPedido.Remove(detallePedido);
                    var entry = this.iConexion!.Entry<detallesPedido>(detallePedido!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return detallePedido;
                }
                throw new Exception("El detalle no existe");
            }
            catch
            {
                throw new Exception("No se pudo modificar el detalle del pedido");
            }
        }

         

        public decimal calcularSubTotal(int detalleId)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var detallePedido = this.iConexion!.detallesPedido!.Find(detalleId);
                var prod = this.iConexion.productos!.Find(detallePedido!.producto);
                var prodExtra = this.iConexion.producto_Extra!.Find(detallePedido!.producto_Extra);
                decimal subtotal = 0;

                if (detallePedido != null && prod != null && prodExtra != null)
                {
                    decimal valorProducto = prod!.precio;
                    decimal precioExtra = prodExtra!.precioAdicional;
                    subtotal = (detallePedido.cantidad * valorProducto)
                             + (detallePedido.cantidadExtra * precioExtra);

                    if (detallePedido.subtotal == 0)
                    {
                        var entry = this.iConexion!.Entry<detallesPedido>(detallePedido!);
                        entry.State = EntityState.Modified;
                        detallePedido.subtotal = subtotal;
                        this.iConexion.SaveChanges();
                        return subtotal;
                    }
                }
                throw new Exception("No se pudo calcular el subtotal");
            }
            catch
            {
                throw new Exception("No se pudo guardar el detalle del pedido");
            }
        }

    }
}
