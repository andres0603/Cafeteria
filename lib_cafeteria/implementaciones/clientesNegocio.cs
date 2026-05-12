

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

        public List<clientes> Consultar()
        {
            try 
            { 
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var lista = this.iConexion.clientes!.ToList();
                return lista;
            }
            catch
            {
                throw new Exception("No se pudo encontrar el cliente");
            }
        }

        public clientes Guardar(clientes entidad)
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
                throw new Exception("No se pudo guardar el cliente");
            }
}

        public clientes Modificar(clientes entidad)
        {
            try
            {


                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var entry = this.iConexion!.Entry<clientes>(entidad!);
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
                throw new Exception("No se pudo modificar el cliente");
            }

            if (entidad.id != 0)
                return entidad;
            throw new Exception("");
        }

        public clientes Borrar(int id)
        {
            try
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


                var cliente = this.iConexion.clientes!.Find(id);

                if (cliente != null)
                {

                    this.iConexion.clientes.Remove(cliente);
                    var entry = this.iConexion!.Entry<clientes>(cliente!);

                    var historicos = new historicos
                    {
                        nombreTabla = entry.Metadata.GetTableName(),
                        accion = entry.State.ToString(),
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
