

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class proveedoresNegocio : IProveedoresNegocio
    {
        private IConexion? iConexion;

        public List<proveedores> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Proveedores",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.proveedores!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el proveedor");
            }
        }

        public proveedores Guardar(proveedores entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.proveedores!.Add(entidad!);
                var entry = this.iConexion!.Entry<proveedores>(entidad!);

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
                throw new Exception("No se pudo guardar el proveedor");
            }
        }

        public proveedores Modificar(proveedores entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<proveedores>(entidad!);
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
                throw new Exception("No se pudo modificar el proveedor");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public proveedores Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var proveedor = this.iConexion.proveedores!.Find(id);

                if (proveedor != null)
                {

                    this.iConexion.proveedores.Remove(proveedor);
                    var entry = this.iConexion!.Entry<proveedores>(proveedor!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return proveedor;
                }

                throw new Exception("El proveedor no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el proveedor");
            }
        }
    }
}
