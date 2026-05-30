

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class mesasNegocio : IMesasNegocio
    {
        private IConexion? iConexion;

        public List<mesas> Consultar(string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    usuario=usuario,
                    nombreTabla = "Mesas",
                    accion = "Consultar",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);

                var lista = this.iConexion.mesas!
                    .Include(x => x._estadoMesa)
                    .Include(x=>x._sedes)
                    .ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar la mesa");
            }
        }

        public mesas Guardar(mesas entidad, string usuario)
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
                throw new Exception("No se pudo guardar la mesa");
            }
        }

        public mesas Modificar(mesas entidad, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<mesas>(entidad!);
                entry.State = EntityState.Modified;
                var historicos = new historicos
                {
                    usuario = usuario,
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

        public mesas Borrar(mesas mesa, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                if (mesa != null)
                {

                    this.iConexion.mesas.Remove(mesa);
                    var entry = this.iConexion!.Entry<mesas>(mesa!);

                    var historicos = new historicos
                    {
                        usuario = usuario,
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = "Borrar",
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
