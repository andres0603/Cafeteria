
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class reservasModel : PageModel
    {
        private IreservasNegocio? IreservasNegocio;
        private IestadoReservaNegocio? IestadoReservaNegocio;
        private IclientesNegocio? IclientesNegocio;
        [BindProperty] public List<reservas>? Lista { get; set; }
        [BindProperty] public List<estadoReserva>? ListaEstadoReserva { get; set; }
        [BindProperty] public List<clientes>? ListaClientes { get; set; }
        [BindProperty] public reservas? reserva { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public reservasModel()
        {
            IreservasNegocio = new ReservasNegocio();
            IestadoReservaNegocio = new EstadoReservaNegocio();
            IclientesNegocio = new ClientesNegocio();
        }

        public void OnPostBtNuevo()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            ListaEstadoReserva = IestadoReservaNegocio!.Consultar(usuario!);
            ListaClientes = IclientesNegocio!.Consultar(usuario!);
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IreservasNegocio == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                Lista = IreservasNegocio.Consultar(usuario!);
                reserva = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                OnPostBtNuevo();
                reserva = Lista!.FirstOrDefault(x => x.id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                var usuario = HttpContext.Session.GetString("Usuario");
                if (reserva == null)
                    return;
                if (reserva.id == 0)
                    reserva = IreservasNegocio!.Guardar(reserva!, usuario!);
                else
                    reserva = IreservasNegocio!.Modificar(reserva!, usuario!);
                if (reserva.id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar(int data)
        {
            try
            {
                if (reserva == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                reserva = IreservasNegocio!.Borrar(reserva!, usuario!);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                reserva = Lista!.FirstOrDefault(x => x.id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }

    }
}