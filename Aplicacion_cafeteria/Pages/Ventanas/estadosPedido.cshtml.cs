
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class estadosPedidoModel : PageModel
    {
        private IestadosPedidoNegocio? IestadosPedidoNegocio;
        [BindProperty] public List<estadosPedido>? Lista { get; set; }
        [BindProperty] public estadosPedido? categoria { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public estadosPedidoModel()
        {
            IestadosPedidoNegocio = new EstadosPedidoNegocio();
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
                if (IestadosPedidoNegocio == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                Lista = IestadosPedidoNegocio.Consultar(usuario!);
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
                    categoria = IestadosPedidoNegocio!.Guardar(categoria!, usuario!);
                else
                    categoria = IestadosPedidoNegocio!.Modificar(categoria!, usuario!);
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
                if (categoria == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                categoria = IestadosPedidoNegocio!.Borrar(categoria!,usuario);
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