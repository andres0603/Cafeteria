
using lib_cafeteria.modelos;
using Lib_presentaciones.Configuraciones;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aplicacion_cafeteria.Pages
{
    public class pedidosModel : PageModel
    {
        private IpedidosNegocio? IpedidosNegocio;
        private IestadosPedidoNegocio? IestadosPedidoNegocio;
        private IclientesNegocio? IclientesNegocio;
        [BindProperty] public List<pedidos>? Lista { get; set; }
        [BindProperty] public List<clientes>? ListaClientes { get; set; }
        [BindProperty] public List<estadosPedido>? ListaEstadoPedido { get; set; }
        [BindProperty] public pedidos? pedidos { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public pedidosModel()
        {
            IpedidosNegocio = new PedidosNegocio();
            IestadosPedidoNegocio = new EstadosPedidoNegocio();
            IclientesNegocio = new ClientesNegocio();
        }

        public void OnPostBtNuevo()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            ListaClientes = IclientesNegocio!.Consultar(usuario!);
            ListaEstadoPedido = IestadosPedidoNegocio!.Consultar(usuario!);
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IpedidosNegocio == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                Lista = IpedidosNegocio.Consultar(usuario!);
                pedidos = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public IActionResult OnPostBtReporte()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            var lista = IpedidosNegocio!.Consultar(usuario!); // usa tu método de listar
            var pdf = ReportePedidos.Generar(lista);
            return File(pdf, "application/pdf", "ReportePedidos.pdf");
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                OnPostBtNuevo();
                pedidos = Lista!.FirstOrDefault(x => x.id == data);
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
                if (pedidos == null)
                    return;
                if (pedidos.id == 0)
                    pedidos = IpedidosNegocio!.Guardar(pedidos!, usuario!);
                else
                    pedidos = IpedidosNegocio!.Modificar(pedidos!, usuario!);
                if (pedidos.id == 0)
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
                if (pedidos == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                pedidos = IpedidosNegocio!.Borrar(pedidos!, usuario!);
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
                pedidos = Lista!.FirstOrDefault(x => x.id == data);
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