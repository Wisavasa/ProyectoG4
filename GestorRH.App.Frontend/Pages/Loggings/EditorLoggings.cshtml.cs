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
    public class EditorLoggingsModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        [BindProperty]
        public Logging logging { get; set; }
        public Logging log { get; set; }

        public EditorLoggingsModel()
        {
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? loggingId, int? Super)
        {
            if (loggingId.HasValue)
            {
                logging = _repoLogging.GetLogging(loggingId.Value);
            }
            else
            {
               
                return RedirectToPage("./NotFound");
            }
            if (Super.HasValue)
            {
                log = _repoLogging.GetLogging(Super.Value);
                return Page();
            }else{
                return RedirectToPage("/Index");
            }
        }

        public IActionResult OnPost( int Super)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else 
            {
                log = _repoLogging.GetLogging(Super);
                logging = _repoLogging.UpdateLogging(logging);
            }
            TempData["success"]="Usuario Editado Correctamente";
            return RedirectToPage("./EditarLoggings", new { Super = log.Id});
        }
    }
}
