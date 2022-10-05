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
    public class EliminarLoggingsModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        [BindProperty]
        public IEnumerable<Logging> logging { get; set; }
        [BindProperty]
        public Logging loggingFiltro { get; set; }
        public Logging log { get; set; }

        public EliminarLoggingsModel()
        {
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }

        public IActionResult OnGet(string? datofiltro, int? Super)
        {
            if (Super.HasValue)
            {
                log = _repoLogging.GetLogging(Super.Value);
                
            }else{
                return RedirectToPage("/Index");
            }
            if (datofiltro!=null)
            {
                logging= _repoLogging.GetLoggingsPorFiltro(loggingFiltro.Usuario);
                return Page();     
            }
            else
            {
                logging = _repoLogging.GetAllLoggings();
                return Page(); 
            }
        }

        public IActionResult OnPost(int loggingId, int Super)
        { 
            log = _repoLogging.GetLogging(Super);           
            logging= _repoLogging.GetLoggingsPorFiltro(loggingFiltro.Usuario);
            if(loggingId>0){
                _repoLogging.DeleteLogging(loggingId);
                TempData["success"]="Logging Eliminado Correctamente";
                return RedirectToPage("./EliminarLoggings",new { Super = log.Id});
            }
            return Page();            
            
        }
    }
}
