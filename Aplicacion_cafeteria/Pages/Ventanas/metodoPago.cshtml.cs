using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class metodoPagoModel : PageModel
    {
        private ImetodoPagoNegocio? ImetodoPagoNegocio;
        [BindProperty] public List<metodoPago>? Lista { get; set; }
        [BindProperty] public metodoPago? metodoPago { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public metodoPagoModel()
        {
            ImetodoPagoNegocio = new MetodoPagoNegocio();
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
                if (ImetodoPagoNegocio == null)
                    return;
                Lista = ImetodoPagoNegocio.Consultar();
                metodoPago = null;
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
                metodoPago = Lista!.FirstOrDefault(x => x.id == data);
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

                if (metodoPago == null)
                    return;
                if (metodoPago.id == 0)
                    metodoPago = ImetodoPagoNegocio!.Guardar(metodoPago!);
                else
                    metodoPago = ImetodoPagoNegocio!.Modificar(metodoPago!);
                if (metodoPago.id == 0)
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
                OnPostBtRefrescar();
                metodoPago = Lista!.FirstOrDefault(x => x.id == data);
                if (metodoPago == null)
                    return;
                metodoPago = ImetodoPagoNegocio!.Borrar(metodoPago!);

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
                metodoPago = Lista!.FirstOrDefault(x => x.id == data);
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