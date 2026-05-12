

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class mesasNegocio : IMesasNegocio
    {
        private IConexion? iConexion;

        public List<mesas> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var lista = this.iConexion.mesas!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar la mesa");
            }
        }

        public mesas Guardar(mesas entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.mesas!.Add(entidad!);
                var entry = this.iConexion!.Entry<mesas>(entidad!);

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
                throw new Exception("No se pudo guardar la mesa");
            }
        }

        public mesas Modificar(mesas entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<mesas>(entidad!);
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
                throw new Exception("No se pudo modificar la mesa");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public mesas Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var mesa = this.iConexion.mesas!.Find(id);

                if (mesa != null)
                {

                    this.iConexion.mesas.Remove(mesa);
                    var entry = this.iConexion!.Entry<mesas>(mesa!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return mesa;
                }

                throw new Exception("La mesa no existe");
            }
            catch
            {
                throw new Exception("No se pudo guardar la mesa");
            }
        }
    }
}
