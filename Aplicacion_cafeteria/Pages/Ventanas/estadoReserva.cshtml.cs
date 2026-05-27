
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class estadoReservaModel : PageModel
    {
        private IestadoReservaNegocio? IestadoReservaNegocio;
        [BindProperty] public List<estadoReserva>? Lista { get; set; }
        [BindProperty] public estadoReserva? estadoReserva { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public estadoReservaModel()
        {
            IestadoReservaNegocio = new EstadoReservaNegocio();
        }

        public void OnPostBtNuevo()
        {
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IestadoReservaNegocio == null)
                    return;
                Lista = IestadoReservaNegocio.Consultar();
                estadoReserva = null;
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
                estadoReserva = Lista!.FirstOrDefault(x => x.id == data);
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

                if (estadoReserva == null)
                    return;
                if (estadoReserva.id == 0)
                    estadoReserva = IestadoReservaNegocio!.Guardar(estadoReserva!);
                else
                    estadoReserva = IestadoReservaNegocio!.Modificar(estadoReserva!);
                if (estadoReserva.id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (estadoReserva == null)
                    return;
                estadoReserva = IestadoReservaNegocio!.Borrar(estadoReserva!);
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
                estadoReserva = Lista!.FirstOrDefault(x => x.id == data);
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