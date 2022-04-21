using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Solicitud
{
    public class GridModel : PageModel
    {
        private readonly ISolicitudService solicitud;

        public GridModel(ISolicitudService solicitud)
        {
            this.solicitud = solicitud;
        }

        public IEnumerable<SolicitudEntity> GridList { get; set; } = new List<SolicitudEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await solicitud.GET();

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
                var result = await solicitud.DELETE(new()
                { IdSolicitud = id });

                if (result.CodError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "La solicitud fue eliminada satisfactoriamente";

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
