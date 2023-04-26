using AvisFormation.Models;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class AvisController : Controller
    {
        IFormationRepository _formationRepository;
        IAvisRepository _avisRepository;
        public AvisController(IFormationRepository formationRepository, IAvisRepository avisRepository)
        { 
            _formationRepository= formationRepository;
            _avisRepository= avisRepository;
        }

        [Authorize]
        public IActionResult LaisserUnAvis(string idFormation)
        {
            int iIdFormation = -1;
            if (!Int32.TryParse(idFormation, out iIdFormation))
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }

            var formation = _formationRepository.GetFormationById(iIdFormation);

            if (formation == null)
            {
                return RedirectToAction("ToutesLesFormations", "Formation");
            }

            var vm = new LaisserUnAvisViewModel();
            vm.NomFormation = formation.name;
            vm.IdFormation = formation.Id.ToString();
            
            return View(vm);
        }

        [Authorize]
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

            _avisRepository.SaveAvis(viewModel.Commentaire, viewModel.Nom, viewModel.IdFormation, viewModel.Note);

            return RedirectToAction("DetailsFormation", "Formation", new { idFormation = viewModel.IdFormation });
        }
    }
}
