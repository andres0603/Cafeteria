
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aplicacion_cafeteria.Pages
{
    public class pagosModel : PageModel
    {
        private IpagosNegocio? IpagosNegocio;
        private IpedidosNegocio? IpedidosNegocio;
        private ImetodoPagoNegocio? ImetodoPagoNegocio;
        [BindProperty] public List<pagos>? Lista { get; set; }
        [BindProperty] public List<pedidos>? ListaPedidos { get; set; }
        [BindProperty] public List<metodoPago>? ListaMetodo { get; set; }
        [BindProperty] public pagos? pagos { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public pagosModel()
        {
            IpagosNegocio = new PagosNegocio();
            ImetodoPagoNegocio = new MetodoPagoNegocio();
            IpedidosNegocio = new PedidosNegocio();
        }

        public void OnPostBtNuevo()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            ListaPedidos = IpedidosNegocio!.Consultar(usuario!);
            ListaMetodo = ImetodoPagoNegocio!.Consultar(usuario!);
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IpagosNegocio == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                Lista = IpagosNegocio.Consultar(usuario!);
                pagos = null;
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
                pagos = Lista!.FirstOrDefault(x => x.id == data);
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
                if (pagos == null)
                    return;
                if (pagos.id == 0)
                    pagos = IpagosNegocio!.Guardar(pagos!, usuario!);
                else
                    pagos = IpagosNegocio!.Modificar(pagos!, usuario!);
                if (pagos.id == 0)
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
                if (pagos == null)
                    return;
                pagos = IpagosNegocio!.Borrar(pagos!, usuario!);
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
                pagos = Lista!.FirstOrDefault(x => x.id == data);
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