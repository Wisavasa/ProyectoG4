using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestorRH.App.Dominio;
using GestorRH.App.Persistencia;

namespace GestorRH.App.Frontend.Pages
{
    public class CrearLoggingsModel : PageModel
    {
        private readonly IRepositorioLogging _repoLoggings;
        [BindProperty]
        public Logging logging { get; set; }
        
        public Logging log { get; set; }

        public CrearLoggingsModel()
        {
            this._repoLoggings = new RepositorioLogging(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? Super)
        {
            logging = new Logging();
            if (Super.HasValue)
            {
                log = _repoLoggings.GetLogging(Super.Value);
                return Page();
            }else{
                return RedirectToPage("/Index");
            }
            Page();
        }

        public IActionResult OnPost(Logging logging, int Super)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }else{
                log = _repoLoggings.GetLogging(Super); 
                logging=_repoLoggings.AddLogging(logging);
                TempData["success"]="Usuario Creado Correctamente"; 
                return RedirectToPage("./ListaLoggings",new { Super = log.Id});
            }                         
            return Page();
        }        
    }
}
