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
    public class ListaCargosModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        private readonly IRepositorioCargo _repocargos;
        public IEnumerable<Cargo> listacargos {get;set;}
        [BindProperty]
        public Cargo cargoFiltro { get; set; }
        public Logging logging { get; set; }
        public ListaCargosModel()
        {
            this._repocargos = new RepositorioCargo(new Persistencia.AppContext());
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
                listacargos= _repocargos.GetCargosPorFiltro(cargoFiltro.NombreCargo);
                return Page();     
            }
            else
            {
                listacargos = _repocargos.GetAllCargos();
                return Page(); 
            }
        }
        public IActionResult OnPost(int Super)
        {
            
            listacargos= _repocargos.GetCargosPorFiltro(cargoFiltro.NombreCargo);
            logging = _repoLogging.GetLogging(Super);
            TempData["success"]="Cargos Filtrados Correctamente";
            return Page();            
            
        }


    }
}
