
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
                Lista = IestadosPedidoNegocio.Consultar();
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

                if (categoria == null)
                    return;
                if (categoria.id == 0)
                    categoria = IestadosPedidoNegocio!.Guardar(categoria!);
                else
                    categoria = IestadosPedidoNegocio!.Modificar(categoria!);
                if (categoria.id == 0)
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
                categoria = Lista!.FirstOrDefault(x => x.id == data);
                if (categoria == null)
                    return;
                categoria = IestadosPedidoNegocio!.Borrar(categoria!);
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