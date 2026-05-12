

using lib_cafeteria.modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_cafeteria.interfaces
{
    public interface IConexion
    {
        string? string_conexion { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        DbSet<categorias> categorias { get; set; }
        DbSet<clientes> clientes { get; set; }
        DbSet<detallesPedido> detallesPedido { get; set; }
        DbSet<empleados> empleados { get; set; }
        DbSet<estadoReserva> estadoReserva { get; set; }
        DbSet<estadosMesa> estadosMesa { get; set; }
        DbSet<estadosPedido> estadosPedido { get; set; }
        DbSet<horarios> horarios { get; set; }
        DbSet<mesas> mesas { get; set; }
        DbSet<metodoPago> metodoPago { get; set; }
        DbSet<pagos> pagos { get; set; }
        DbSet<pedidos> pedidos { get; set; }
        DbSet<personas> personas { get; set; }
        DbSet<producto_Extra> producto_Extra { get; set; }
        DbSet<producto_proveedor> producto_proveedor { get; set; }
        DbSet<productos> productos { get; set; }
        DbSet<proveedores> proveedores { get; set; }
        DbSet<reservas> reservas { get; set; }
        DbSet<roles> roles { get; set; }
        DbSet<sedes> sedes { get; set; }
        DbSet<tareas> tareas { get; set; }
        DbSet<historicos> historicos { get; set; }
        DbSet<historial_login> historial_login { get; set; }
        DbSet<sesiones> sesiones { get; set; }
        DbSet<usuario_roles> usuario_roles { get; set; }
        DbSet<usuarios> usuarios { get; set; }
    }
}