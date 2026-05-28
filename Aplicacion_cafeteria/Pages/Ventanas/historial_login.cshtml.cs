

using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class historial_loginModel : PageModel
    {
        private Ihistorial_loginNegocio? Ihistorial_loginNegocio;
        [BindProperty] public List<historial_login>? Lista { get; set; }
        [BindProperty] public historial_login? historico { get; set; }

        public historial_loginModel()
        {
            Ihistorial_loginNegocio = new Historial_loginNegocio();
        }


        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (Ihistorial_loginNegocio == null)
                    return;
                Lista = Ihistorial_loginNegocio.Consultar();
                historico = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

    }
}