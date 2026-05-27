

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class usuario_rolesNegocio:IUsuario_rolesNegocio
    {
        private IConexion? iConexion;

        public List<usuario_roles> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Usuario_Roles",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.usuario_roles!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el usuario con respecto al rol");
            }
        }

        public usuario_roles Guardar(usuario_roles entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.usuario_roles!.Add(entidad!);
                var entry = this.iConexion!.Entry<usuario_roles>(entidad!);

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
                throw new Exception("No se pudo guardar el usuario con respecto al rol");
            }
        }

        public usuario_roles Modificar(usuario_roles entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<usuario_roles>(entidad!);
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
                throw new Exception("No se pudo modificar el usuario con respecto al rol");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public usuario_roles Borrar(usuario_roles usuario_Rol)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");



                if (usuario_Rol != null)
                {

                    this.iConexion.usuario_roles.Remove(usuario_Rol);
                    var entry = this.iConexion!.Entry<usuario_roles>(usuario_Rol!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return usuario_Rol;
                }

                throw new Exception("El usuario con respecto al rol no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el usuario con respecto al rol");
            }
        }
    }
}
