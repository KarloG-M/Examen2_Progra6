using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Servicios
{
    public class EditModel : PageModel
    {
        private readonly IServicioService servicio;
        public EditModel(IServicioService servicio)
        {
            this.servicio = servicio;
        }

        public IServicioService Servicio { get; }

        public void OnGet()
        {

        }
    }
}
