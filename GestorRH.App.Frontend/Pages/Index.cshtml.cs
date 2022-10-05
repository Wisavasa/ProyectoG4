using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestorRH.App.Dominio;
using GestorRH.App.Persistencia;

namespace GestorRH.App.Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        public IEnumerable<Logging> logging { get; set; }
        [BindProperty]
        public Logging loggingFiltro { get; set; }
        

        public IndexModel()
        {
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }

        public void OnGet()
        {
        }     

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                logging= _repoLogging.GetLoggingsPorFiltro(loggingFiltro.Usuario);
                if (logging.Count() != 1){
                    TempData["success"]="Usuario no encontrado";
                    return Page();
                }else{
                    if(logging.FirstOrDefault().Contrasena == loggingFiltro.Contrasena){
                        if(logging.FirstOrDefault().SuperUser == true){
                            TempData["success"]="Usuario logeado correctamente";
                            return RedirectToPage("./Inicial/SuperUser", new { Super = logging.FirstOrDefault().Id});
                        }else{
                            TempData["success"]="Usuario logeado correctamente";
                            return RedirectToPage("./Inicial/User", new { Super = logging.FirstOrDefault().Id});
                        }
                    }
                    TempData["success"]="Contraseña incorrecta"; 
                    return Page();
                }                         
                return Page();
            }else{
                return Page();
            }
        }        
    }     
}
