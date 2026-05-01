

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;


namespace lib_cafeteria.implementaciones
{
    public class sedesNegocio : ISedesNegocio
    {
        private IConexion? iConexion;

        public List<sedes> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = this.iConexion.sedes!.ToList();
            return lista;
        }

        public sedes Guardar(sedes entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");


            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.sedes!.Add(entidad!);
            var entry = this.iConexion!.Entry<sedes>(entidad!);

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

        public sedes Modificar(sedes entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<sedes>(entidad!);
            entry.State = EntityState.Modified;
            var historicos = new historicos
            {
                nombreTabla = entry.Metadata.GetTableName(),
                accion = entry.State.ToString(),
                fechaCambio = DateTime.Now
            };
            this.iConexion.historicos!.Add(historicos);
            this.iConexion!.SaveChanges();

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public sedes Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


            var Arbol = this.iConexion.sedes!.Find(id);

            if (Arbol != null)
            {

                this.iConexion.sedes.Remove(Arbol);
                var entry = this.iConexion!.Entry<sedes>(Arbol!);

                var historicos = new historicos
                {
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = entry.State.ToString(),
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                this.iConexion.SaveChanges();
                return Arbol;
            }

            throw new Exception("El arbol no existe");
        }
        public List<mesas> ObtenerMesasDisponibles(int personas)
        {

            this.iConexion  = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            return iConexion?.mesas?.Where(m => m.activo &&
                                     m.estadoMesa == 1 &&
                                     m.capacidad >= personas)
                         .OrderBy(m => m.capacidad)
                         .ToList() ?? new List<mesas>();
        }
    }
}
