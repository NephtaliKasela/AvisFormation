using Data;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class FormationController : Controller
    {
        IFormationRepository _repository;
        public FormationController(IFormationRepository repository)
        {
            _repository= repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ToutesLesFormations()
        {
            var listFormations = _repository.GetAllFormations();
            return View(listFormations);

        }

        public IActionResult DetailsFormation(string idFormation)
        {
            int iIdFormation = -1;
            if(!Int32.TryParse(idFormation, out iIdFormation))
            {
                return RedirectToAction("ToutesLesFormations");
            }

            var formation = _repository.GetFormationById(iIdFormation);

            if(formation == null)
            {
                return RedirectToAction("ToutesLesFormations");
            }    

            return View(formation);
        }
    }
}
