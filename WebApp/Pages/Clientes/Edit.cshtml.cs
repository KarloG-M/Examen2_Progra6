using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly IClienteService cliente;
        public EditModel(IClienteService cliente)
        {
            this.cliente = cliente;
        }

        public IClienteService Servicio { get; }
        public void OnGet()
        {
        }
    }
}
