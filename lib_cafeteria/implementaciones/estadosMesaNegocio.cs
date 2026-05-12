
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;
using System;

namespace lib_cafeteria.implementaciones
{
    public class estadosMesaNegocio : IEstadosMesaNegocio
    {
        private IConexion? iConexion;

        public List<estadosMesa> Consultar()
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var lista = this.iConexion.estadosMesa!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el estado de mesa");
            }
        }

        public estadosMesa Guardar(estadosMesa entidad)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.estadosMesa!.Add(entidad!);
                var entry = this.iConexion!.Entry<estadosMesa>(entidad!);

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
                throw new Exception("No se pudo guardar el estado de mesa");
            }
        }

        public estadosMesa Modificar(estadosMesa entidad)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<estadosMesa>(entidad!);
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
                throw new Exception("No se pudo modificar el estado de mesa");
            }
            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public estadosMesa Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var estadoMesa = this.iConexion.estadosMesa!.Find(id);

                if (estadoMesa != null)
                {

                    this.iConexion.estadosMesa.Remove(estadoMesa);
                    var entry = this.iConexion!.Entry<estadosMesa>(estadoMesa!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return estadoMesa;
                }

                throw new Exception("El estado de la mesa no existe");
            }
            catch
            {
                throw new Exception("No se pudo guardar el estado de mesa");
            }
        }

        public string saberSiSePuedeAsignar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var estadoMesas = this.iConexion.estadosMesa!.Find(id);
            if (!estadoMesas!.activo)
            {
                estadoMesas.PermiteAsignarPedido = false;
                return "Mesa Inactiva / Fuera de Servicio";
            }
            else
            {
                estadoMesas.PermiteAsignarPedido = true;
                return "Mesa disponible";
            }
        }
    }
}
