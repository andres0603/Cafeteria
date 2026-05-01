

using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Microsoft.EntityFrameworkCore;

namespace lib_cafeteria.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? string_conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.string_conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<categorias> categorias { get; set; }
        public DbSet<clientes> clientes { get; set; }
        public DbSet<detallesPedido> detallesPedido { get; set; }
        public DbSet<empleados> empleados { get; set; }
        public DbSet<estadoReserva> estadoReserva { get; set; }
        public DbSet<estadosMesa> estadosMesa { get; set; }
        public DbSet<estadosPedido> estadosPedido { get; set; }
        public DbSet<horarios> horarios { get; set; }
        public DbSet<mesas> mesas { get; set; }
        public DbSet<metodoPago> metodoPago { get; set; }
        public DbSet<pagos> pagos { get; set; }
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<personas> personas { get; set; }
        public DbSet<producto_Extra> producto_Extra { get; set; }
        public DbSet<historicos> historicos { get; set; }
        public DbSet<producto_proveedor> producto_proveedor { get; set; }
        public DbSet<productos> productos { get; set; }
        public DbSet<proveedores> proveedores { get; set; }
        public DbSet<reservas> reservas { get; set; }
        public DbSet<roles> roles { get; set; }
        public DbSet<sedes> sedes { get; set; }
        public DbSet<tareas> tareas { get; set; }
    }
}
