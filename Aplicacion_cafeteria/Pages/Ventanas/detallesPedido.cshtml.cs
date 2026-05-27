
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aplicacion_cafeteria.Pages
{
    public class detallesPedidoModel : PageModel
    {
        private IdetallesPedidoNegocio? IdetallesPedidoNegocio;
        private IproductosNegocio? IproductosNegocio;
        private Iproducto_ExtraNegocio? Iproducto_ExtraNegocio;
        private IpedidosNegocio? IpedidosNegocio;
        [BindProperty] public List<detallesPedido>? Lista { get; set; }
        [BindProperty] public List<pedidos>? ListaPedidos { get; set; }
        [BindProperty] public List<productos>? ListaProductos { get; set; }
        [BindProperty] public List<producto_Extra>? ListaProductoExtra { get; set; }
        [BindProperty] public detallesPedido? detallePedido { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public detallesPedidoModel()
        {
            IdetallesPedidoNegocio = new DetallesPedidoNegocio();
            IproductosNegocio= new ProductosNegocio();
            Iproducto_ExtraNegocio = new Producto_ExtraNegocio();
            IpedidosNegocio = new PedidosNegocio();
        }

        public void OnPostBtNuevo()
        {
            ListaPedidos = IpedidosNegocio!.Consultar();
            ListaProductos = IproductosNegocio!.Consultar();
            ListaProductoExtra = Iproducto_ExtraNegocio.Consultar();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IdetallesPedidoNegocio == null)
                    return;
                Lista = IdetallesPedidoNegocio.Consultar();
                detallePedido = null;
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
                detallePedido = Lista!.FirstOrDefault(x => x.id == data);
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

                if (detallePedido == null)
                    return;
                if (detallePedido.id == 0)
                    detallePedido = IdetallesPedidoNegocio!.Guardar(detallePedido!);
                else
                    detallePedido = IdetallesPedidoNegocio!.Modificar(detallePedido!);
                if (detallePedido.id == 0)
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
                if (detallePedido == null)
                    return;
                detallePedido = IdetallesPedidoNegocio!.Borrar(detallePedido!);
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
                detallePedido = Lista!.FirstOrDefault(x => x.id == data);
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