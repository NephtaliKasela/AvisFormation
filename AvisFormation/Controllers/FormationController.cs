using AvisFormation.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
            var vm = new List<DetailFormationViewModel>();
            foreach (var f in listFormations)
            {
                vm.Add(new DetailFormationViewModel { Formation = f, NoteMoyenne = (float)f.Avis.Select(a => a.Note).DefaultIfEmpty(0).Average() });
            }

            return View(vm);

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

            var vm = new DetailFormationViewModel();
            vm.Formation = formation;
            if(formation.Avis != null && formation.Avis.Count > 0)
            {
                vm.NoteMoyenne = (float)formation.Avis.Select(a => a.Note).ToList().Average();
            }

            return View(vm);
        }
    }
}
