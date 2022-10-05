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
    public class SuperUserModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        public IEnumerable<Trabajador> listaTrabajadores {get;set;}
        [BindProperty]
        public Logging logging { get; set; }
        public Trabajador trabajador { get; set; }
        public SuperUserModel()
        {
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? Super)
        {   
            
            if (Super.HasValue)
            {
                logging = _repoLogging.GetLogging(Super.Value);
                if(logging.SuperUser == true){
                    return Page();
                }else{
                    return RedirectToPage("./User",new { Super = logging.Id});
                }
            }else{
                return RedirectToPage("/Index");
            }return Page(); 
        }
        public IActionResult OnPost()
        {                        
            return Page();
        }


    }
}
