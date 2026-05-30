

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class rolesNegocio: IRolesNegocio
    {
        private IConexion? iConexion;

        public List<roles> Consultar(string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    usuario=usuario,
                    nombreTabla = "Roles",
                    accion = "Consultar",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.roles!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el rol");
            }
        }

        public roles Guardar(roles entidad, string usuario)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.roles!.Add(entidad!);
                var entry = this.iConexion!.Entry<roles>(entidad!);

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
                throw new Exception("No se pudo guardar el rol");
            }
        }

        public roles Modificar(roles entidad, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<roles>(entidad!);
                entry.State = EntityState.Modified;
                var historicos = new historicos
                {
                    usuario = usuario,
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = "Modificar",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                this.iConexion!.SaveChanges();
            }
            catch
            {
                throw new Exception("No se pudo modificar el rol");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public roles Borrar(roles rol, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                if (rol != null)
                {

                    this.iConexion.roles.Remove(rol);
                    var entry = this.iConexion!.Entry<roles>(rol!);

                    var historicos = new historicos
                    {
                        usuario = usuario,
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = "Borrar",
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return rol;
                }

                throw new Exception("El rol no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el rol");
            }
        }
        public decimal calcularValorDia(int rolId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var rol = this.iConexion!.roles!.Find(rolId);
            decimal valorDia = 0;

            if (rol != null)
            {
                valorDia = rol.salarioBase / 30;

                if (rol.valor_dia == 0)
                {
                    var entry = this.iConexion!.Entry<roles>(rol!);
                    entry.State = EntityState.Modified;
                    rol.valor_dia = valorDia;
                    this.iConexion.SaveChanges();
                }
                return valorDia;
            }
            throw new Exception("No se pudo calcular el valor del dia");
            
        }
    }
}
