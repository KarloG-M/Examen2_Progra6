using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Servicios
{
    public class GridModel : PageModel
    {
       
            private readonly IServicioService servicio;
        public GridModel(IServicioService servicio)
        {
            this.servicio = servicio;
        }
        public IEnumerable<ServicioEntity> GridLista { get; set; } = new List<ServicioEntity>();

        public string Mensaje { get; set; } = "";
        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridLista = await servicio.GET();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {

            try
            {
                var result = await servicio.DELETE(new()
                { IdServicio = id });

                if (result.CodError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El Servicio fue eliminado satisfactoriamente";

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
    
}
