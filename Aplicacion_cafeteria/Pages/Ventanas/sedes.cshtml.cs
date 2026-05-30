
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class sedesModel : PageModel
    {
        private IsedesNegocio? IsedesNegocio;
        [BindProperty] public List<sedes>? Lista { get; set; }
        [BindProperty] public sedes? sede { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public sedesModel()
        {
            IsedesNegocio = new SedesNegocio();
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
                if (IsedesNegocio == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                Lista = IsedesNegocio.Consultar(usuario!);
                sede = null;
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
                sede = Lista!.FirstOrDefault(x => x.id == data);
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
                if (sede == null)
                    return;
                if (sede.id == 0)
                    sede = IsedesNegocio!.Guardar(sede!, usuario!);
                else
                    sede = IsedesNegocio!.Modificar(sede!, usuario!);
                if (sede.id == 0)
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
                if (sede == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                sede = IsedesNegocio!.Borrar(sede!, usuario!);
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
                sede = Lista!.FirstOrDefault(x => x.id == data);
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