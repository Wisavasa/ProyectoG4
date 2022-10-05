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
    public class UserModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        public Logging logging { get; set; }
        public Trabajador trabajador { get; set; }

        public UserModel()
        {
           this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int? Super)
        {
            if (Super.HasValue)
            {
                logging = _repoLogging.GetLogging(Super.Value);
                if(logging.SuperUser == false){    
                    return Page(); 
                }else{
                    return RedirectToPage("/Index");
                }
            } return Page(); 
        }
        public IActionResult OnPost()
        {
            return Page();            
            
        }
    }
}
