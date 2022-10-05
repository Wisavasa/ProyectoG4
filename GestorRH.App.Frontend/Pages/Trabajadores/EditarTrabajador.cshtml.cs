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
    public class EditarTrabajadorModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        private readonly IRepositorioTrabajador _repoTrabajador;
        [BindProperty]
        public IEnumerable<Trabajador> trabajador { get; set; }
        [BindProperty]
        public Trabajador trabajadorFiltro { get; set; }
        public Logging logging { get; set; }

        public EditarTrabajadorModel()
        {
            this._repoTrabajador = new RepositorioTrabajador(new Persistencia.AppContext());
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }

        public IActionResult OnGet(string? datofiltro, int? Super)
        {
            if (Super.HasValue)
            {
                logging = _repoLogging.GetLogging(Super.Value);
                
            }else{
                return RedirectToPage("/Index");
            }
            if (datofiltro!=null)
            {
                trabajador= _repoTrabajador.GetTrabajadorsPorFiltro(trabajadorFiltro.Nombres);
                return Page();     
            }
            else
            {
                trabajador = _repoTrabajador.GetAllTrabajadores();
                return Page(); 
            }
        }

        public IActionResult OnPost(int Super)
        {
            logging = _repoLogging.GetLogging(Super);
            trabajador= _repoTrabajador.GetTrabajadorsPorFiltro(trabajadorFiltro.Nombres);
            TempData["success"]="Trabajadores Filtrados Correctamente";
            return Page();        
            
        }
        
        
    }
}
