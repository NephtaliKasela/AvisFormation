using AvisFormation.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class AvisController : Controller
    {
        public IActionResult LaisserUnAvis(string idFormation)
        {
            int iIdFormation = -1;
            if (!Int32.TryParse(idFormation, out iIdFormation))
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }

            FormationMemoryRepository repository = new FormationMemoryRepository();
            var formation = repository.GetFormationById(iIdFormation);

            if (formation == null)
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }

            var vm = new LaisserUnAvisViewModel();
            vm.NomFormation = formation.name;
            vm.IdFormation = formation.Id.ToString();
            
            return View(vm);
        }

        [HttpPost]
        public IActionResult SaveComment(LaisserUnAvisViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("LaisserUnAvis", viewModel);
            }


            if(string.IsNullOrEmpty(viewModel.NomFormation) || string.IsNullOrEmpty(viewModel.Note))
            {
                return RedirectToAction("LaisserUnAvis", new { idFormation = viewModel.IdFormation });
            }

            AvisRepository repository = new AvisRepository();
            repository.SaveAvis(viewModel.Commentaire, viewModel.Nom, viewModel.IdFormation);

            return RedirectToAction("DetailsFormation", "Formation", new { idFormation = viewModel.IdFormation });
        }
    }
}
