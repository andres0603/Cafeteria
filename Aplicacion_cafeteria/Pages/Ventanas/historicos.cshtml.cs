
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class historicosModel : PageModel
    {
        private IhistoricosNegocio? IhistoricosNegocio;
        [BindProperty] public List<historicos>? Lista { get; set; }
        [BindProperty] public historicos? historico { get; set; }

        public historicosModel()
        {
            IhistoricosNegocio = new HistoricosNegocio();
        }


        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IhistoricosNegocio == null)
                    return;
                Lista = IhistoricosNegocio.Consultar();
                historico = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }
    }
}