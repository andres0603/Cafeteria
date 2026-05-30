
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aplicacion_cafeteria.Pages
{
    public class sesionesModel : PageModel
    {
        private IsesionesNegocio? IsesionesNegocio;
        [BindProperty] public List<sesiones>? Lista { get; set; }
        [BindProperty] public sesiones? historico { get; set; }

        public sesionesModel()
        {
            IsesionesNegocio = new SesionesNegocio();
        }


        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                var usuario = HttpContext.Session.GetString("Usuario");
                if (IsesionesNegocio == null)
                    return;
                Lista = IsesionesNegocio.Consultar(usuario!);
                historico = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }
    }
}