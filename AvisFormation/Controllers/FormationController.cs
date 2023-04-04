using Data;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class FormationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ToutesLesFormations()
        {
            FormationMemoryRepository repository = new FormationMemoryRepository();
            var listFormations = repository.GetAllFormations();
            return View(listFormations);

        }

        public IActionResult DetailsFormation(string idFormation)
        {
            int iIdFormation = -1;
            if(!Int32.TryParse(idFormation, out iIdFormation))
            {
                return RedirectToAction("ToutesLesFormations");
            }

            FormationMemoryRepository repository = new FormationMemoryRepository();
            var formation = repository.GetFormationById(iIdFormation);

            if(formation == null)
            {
                return RedirectToAction("ToutesLesFormations");
            }    

            return View(formation);
        }
    }
}
