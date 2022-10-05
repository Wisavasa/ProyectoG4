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
    public class ListaLoggingsModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        public IEnumerable<Logging> listaLogging {get;set;}
        [BindProperty]
        public Logging logginFiltro { get; set;}
        public Logging logging { get; set; }
        public ListaLoggingsModel()
        {
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }
        public IActionResult OnGet(string? datofiltro,int? Super)
        {
             if (Super.HasValue)
            {
                logging = _repoLogging.GetLogging(Super.Value);
                
            }else{
                return RedirectToPage("/Index");
            }
            if (datofiltro!=null)
            {
                listaLogging= _repoLogging.GetLoggingsPorFiltro(logginFiltro.Usuario);
                return Page();     
            }
            else
            {
                listaLogging = _repoLogging.GetAllLoggings();
                return Page(); 
            }
        }
        public IActionResult OnPost(int Super)
        {
            
            listaLogging= _repoLogging.GetLoggingsPorFiltro(logginFiltro.Usuario);
            logging = _repoLogging.GetLogging(Super);
            TempData["success"]="Usuarios Filtrados Correctamente";
            return Page();            
            
        }
    }
}
