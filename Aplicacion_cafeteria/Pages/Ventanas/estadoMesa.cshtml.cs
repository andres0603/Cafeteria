
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class estadoMesaModel : PageModel
    {
        private IestadoMesaNegocio? IestadoMesaNegocio;
        private IsedesNegocio? IsedesNegocio;
        [BindProperty] public List<estadosMesa>? Lista { get; set; }
        [BindProperty] public estadosMesa? estadoMesa { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public estadoMesaModel()
        {
            IestadoMesaNegocio = new EstadoMesaNegocio();
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
                if (IestadoMesaNegocio == null)
                    return;
                Lista = IestadoMesaNegocio.Consultar();
                estadoMesa = null;
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
                estadoMesa = Lista!.FirstOrDefault(x => x.id == data);
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

                if (estadoMesa == null)
                    return;
                if (estadoMesa.id == 0)
                    estadoMesa = IestadoMesaNegocio!.Guardar(estadoMesa!);
                else
                    estadoMesa = IestadoMesaNegocio!.Modificar(estadoMesa!);
                if (estadoMesa.id == 0)
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
                if (estadoMesa == null)
                    return;
                estadoMesa = IestadoMesaNegocio!.Borrar(estadoMesa!);
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
                estadoMesa = Lista!.FirstOrDefault(x => x.id == data);
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