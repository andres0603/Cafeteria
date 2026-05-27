
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class producto_ExtraModel : PageModel
    {
        private Iproducto_ExtraNegocio? Iproducto_ExtraNegocio;
        [BindProperty] public List<producto_Extra>? Lista { get; set; }
        [BindProperty] public producto_Extra? producto_Extra { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public producto_ExtraModel()
        {
            Iproducto_ExtraNegocio = new Producto_ExtraNegocio();
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
                if (Iproducto_ExtraNegocio == null)
                    return;
                Lista = Iproducto_ExtraNegocio.Consultar();
                producto_Extra = null;
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
                producto_Extra = Lista!.FirstOrDefault(x => x.id == data);
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

                if (producto_Extra == null)
                    return;
                if (producto_Extra.id == 0)
                    producto_Extra = Iproducto_ExtraNegocio!.Guardar(producto_Extra!);
                else
                    producto_Extra = Iproducto_ExtraNegocio!.Modificar(producto_Extra!);
                if (producto_Extra.id == 0)
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
                if (producto_Extra == null)
                    return;
                producto_Extra = Iproducto_ExtraNegocio!.Borrar(producto_Extra!);
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
                producto_Extra = Lista!.FirstOrDefault(x => x.id == data);
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