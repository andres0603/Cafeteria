using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class producto_proveedorNegocio:IProducto_proveedorNegocio
    {
        private IConexion? iConexion;

        public List<producto_proveedor> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "producto_proveedor",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.producto_proveedor!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el producto con respecto al proveedor");
            }
        }

        public producto_proveedor Guardar(producto_proveedor entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.producto_proveedor!.Add(entidad!);
                var entry = this.iConexion!.Entry<producto_proveedor>(entidad!);

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
                throw new Exception("No se pudo guardar el producto con respecto al proveedor");
            }
        }

        public producto_proveedor Modificar(producto_proveedor entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<producto_proveedor>(entidad!);
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
                throw new Exception("No se pudo modificar el producto con respecto al proveedor");
            }
            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public producto_proveedor Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var ProductoProveedor = this.iConexion.producto_proveedor!.Find(id);

                if (ProductoProveedor != null)
                {

                    this.iConexion.producto_proveedor.Remove(ProductoProveedor);
                    var entry = this.iConexion!.Entry<producto_proveedor>(ProductoProveedor!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return ProductoProveedor;
                }

                throw new Exception("El producto con respecto al proveedor no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el producto con respecto al proveedor");
            }
        }
    }
}
