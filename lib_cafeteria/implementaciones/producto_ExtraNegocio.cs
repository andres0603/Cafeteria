

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class producto_ExtraNegocio: IProducto_ExtraNegocio
    {
        private IConexion? iConexion;

        public List<producto_Extra> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Producto_Extra",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.producto_Extra!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el producto extra");
            }
        }

        public producto_Extra Guardar(producto_Extra entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.producto_Extra!.Add(entidad!);
                var entry = this.iConexion!.Entry<producto_Extra>(entidad!);

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
                throw new Exception("No se pudo guardar el producto extra");
            }
        }

        public producto_Extra Modificar(producto_Extra entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<producto_Extra>(entidad!);
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
                throw new Exception("No se pudo modificar el producto extra");
            }
            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public producto_Extra Borrar(producto_Extra producto_Extra)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");



                if (producto_Extra != null)
                {

                    this.iConexion.producto_Extra.Remove(producto_Extra);
                    var entry = this.iConexion!.Entry<producto_Extra>(producto_Extra!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return producto_Extra;
                }

                throw new Exception("El producto no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el producto extra");
            }
        }
    }
}
