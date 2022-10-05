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
    public class EliminarCargosModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        private readonly IRepositorioCargo _repoCargos;
        [BindProperty]
        public IEnumerable<Cargo> cargo { get; set; }
        [BindProperty]
        public Cargo cargoFiltro { get; set; }
        public Logging logging { get; set; }

        public EliminarCargosModel()
        {
            this._repoCargos = new RepositorioCargo(new Persistencia.AppContext());
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
                cargo= _repoCargos.GetCargosPorFiltro(cargoFiltro.NombreCargo);
                return Page();     
            }
            else
            {
                cargo = _repoCargos.GetAllCargos();
                return Page(); 
            }
        }        

        public IActionResult OnPost(int cargoId, int Super)
        {
            cargo= _repoCargos.GetCargosPorFiltro(cargoFiltro.NombreCargo);
            logging = _repoLogging.GetLogging(Super);
            try 
            {
                if(cargoId>0){
                    if(cargoId==1){
                        TempData["success"]="El cargo no se puede eliminar";
                        return RedirectToPage("./EliminarCargos",new { Super = logging.Id});
                    }
                    _repoCargos.DeleteCargo(cargoId);
                    TempData["success"]="Cargo Eliminado Correctamente";
                    return RedirectToPage("./EliminarCargos",new { Super = logging.Id});
                }
                return Page();
            }catch (Exception ex) 
            {
                TempData["success"]="Cambie los trabajadores de cargo antes de eliminarlo";
                return RedirectToPage("./EliminarCargos",new { Super = logging.Id});
            }
        }
    }
}
