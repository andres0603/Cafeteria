

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class sesionesNegocio:ISesionesNegocio
    {
        private IConexion? iConexion;

        public List<sesiones> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    nombreTabla = "Sesiones",
                    accion = "Select",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.sesiones!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar la sesion");
            }
        }

        public sesiones Guardar(sesiones entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.sesiones!.Add(entidad!);
                var entry = this.iConexion!.Entry<sesiones>(entidad!);

                var historicos = new historicos
                {
                    nombreTabla = entry.Metadata.GetTableName(),
                    accion = entry.State.ToString(),
                    fechaCambio = DateTime.Now
                };

                var historico_login = new historial_login
                {
                    id_usuario = entidad.id_usuario,
                    fecha_ingreso = DateTime.Now,
                    resultado = "Exitoso"
                };

                this.iConexion.historial_login!.Add(historico_login);
                this.iConexion.historicos!.Add(historicos);
                this.iConexion.SaveChanges();
                return entidad;
            }
            catch
            {
                var historico_login = new historial_login
                {
                    id_usuario = entidad.id_usuario,
                    fecha_ingreso = DateTime.Now,
                    resultado = "Fallido"
                };
                this.iConexion!.historial_login!.Add(historico_login);
                this.iConexion.SaveChanges();
                throw new Exception("No se pudo guardar la sesion");
            }
        }

        public sesiones Modificar(sesiones entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<sesiones>(entidad!);
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
                throw new Exception("No se pudo modificar la sesion");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public sesiones Borrar(sesiones sesion)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");



                if (sesion != null)
                {

                    this.iConexion.sesiones.Remove(sesion);
                    var entry = this.iConexion!.Entry<sesiones>(sesion!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return sesion;
                }

                throw new Exception("La sesion no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar la sesion");
            }
        }
    }
}
