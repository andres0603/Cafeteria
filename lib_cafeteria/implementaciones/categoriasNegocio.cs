

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class categoriasNegocio: ICategoriasNegocio
    {
        private IConexion? iConexion;

        public List<categorias> Consultar()
        {
            try 
            { 
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var lista = this.iConexion.categorias!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar la categoria");
            }
}

        public categorias Guardar(categorias entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try 
            { 
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.categorias!.Add(entidad!);
                var entry = this.iConexion!.Entry<categorias>(entidad!);

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
                throw new Exception("No se pudo guardar la categoria");
            }
}

        public categorias Modificar(categorias entidad)
        {
            try 
            { 

                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<categorias>(entidad!);
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
                throw new Exception("No se pudo modificar la categoria");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public categorias Borrar(int id)
        {
            try 
            { 
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


            var categoria = this.iConexion.categorias!.Find(id);

            if (categoria != null)
            {

                this.iConexion.categorias.Remove(categoria);
                var entry = this.iConexion!.Entry<categorias>(categoria!);

                var historicos = new historicos
                {
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = entry.State.ToString(),
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                this.iConexion.SaveChanges();
                return categoria;
            }

            throw new Exception("la categoria no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar la categoria");
            }
        }
    }
}
