
using lib_cafeteria.modelos;
using Lib_presentaciones.implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class categoriasModel : PageModel
    {
        private IcategoriasNegocio? ICategoriasNegocio;
        [BindProperty] public List<categorias>? Lista { get; set; }
        [BindProperty] public categorias? categoria { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        [BindProperty] public string? Usuario { get; set; }
        public categoriasModel()
        {
            ICategoriasNegocio = new CategoriasNegocio();
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
                var usuario = HttpContext.Session.GetString("Usuario");
                if (ICategoriasNegocio == null)
                    return;
                Lista = ICategoriasNegocio.Consultar(usuario!);
                categoria = null;
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
                categoria = Lista!.FirstOrDefault(x => x.id == data);
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
                if (categoria == null)
                    return;
                if (categoria.id == 0)
                    categoria = ICategoriasNegocio!.Guardar(categoria!,usuario!);
                else
                    categoria = ICategoriasNegocio!.Modificar(categoria!,usuario!);
                if (categoria.id == 0)
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
                var usuario = HttpContext.Session.GetString("Usuario");
                if (categoria == null)
                    return;
                categoria = ICategoriasNegocio!.Borrar(categoria!, usuario!);
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
                categoria = Lista!.FirstOrDefault(x => x.id == data);
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