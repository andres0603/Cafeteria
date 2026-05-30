

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace lib_cafeteria.implementaciones
{
    public class clientesNegocio : IClientesNegocio
    {
        private IConexion? iConexion;

        public List<clientes> Consultar(string usuario)
        {
            try 
            { 
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                var historicos = new historicos
                {
                    usuario=usuario,
                    nombreTabla = "Clientes",
                    accion = "Consultar",
                    fechaCambio = DateTime.Now
                };
                this.iConexion.historicos!.Add(historicos);
                var lista = this.iConexion.clientes!
                    .Include(x=>x._sedes)
                    .ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el cliente");
            }
        }

        public clientes Guardar(clientes entidad, string usuario)
        {
            if (entidad.id != 0)
                throw new Exception("Ya se guardo");

            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                this.iConexion.clientes!.Add(entidad!);
                var entry = this.iConexion!.Entry<clientes>(entidad!);

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
                throw new Exception("No se pudo guardar el cliente");
            }
}

        public clientes Modificar(clientes entidad, string usuario)
        {
            try
            {


                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<clientes>(entidad!);
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
                throw new Exception("No se pudo modificar el cliente");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public clientes Borrar(clientes cliente, string usuario)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                if (cliente != null)
                {

                    this.iConexion.clientes.Remove(cliente);
                    var entry = this.iConexion!.Entry<clientes>(cliente!);

                    var historicos = new historicos
                    {
                        usuario = usuario,
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = "Borrar",
                        fechaCambio = DateTime.Now
                    };
                    this.iConexion.historicos!.Add(historicos);
                    this.iConexion.SaveChanges();
                    return cliente;
                }

                throw new Exception("El cliente no existe");
            }
            catch
            {
                throw new Exception("No se pudo borrar el cliente");
            }
        }
        public decimal calcularDescuentoLealtad(int clienteId)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var cliente = this.iConexion!.clientes!.Find(clienteId);

            double esAntiguo = (DateTime.Now - cliente!.fechaRegistro).TotalDays;
            decimal porcentajeDescuento = 0;

            if (esAntiguo >= 365)
            {
                porcentajeDescuento = 0.10m;
                return porcentajeDescuento;
            }
                throw new Exception("No se pudo calcular el descuento");           
        }

        public string consultarDescuento(int clienteId)
        {
            string mensaje;
            mensaje = "El descuento del cliente será: " + (calcularDescuentoLealtad(clienteId) * 100).ToString("0") + "%";
            return mensaje;
        }
    }
}
