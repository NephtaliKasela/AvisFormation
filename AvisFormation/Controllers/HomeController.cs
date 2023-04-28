using AvisFormation.Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AvisFormation.Controllers
{
    public class HomeController : Controller
    {
        IFormationRepository _repository;
        public HomeController(IFormationRepository repository) 
        {
            _repository= repository;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var listFormations = _repository.GetFormations(3);
            var vm = new List<DetailFormationViewModel>();
            foreach(var f in listFormations)
            {
                vm.Add(new DetailFormationViewModel { Formation = f, NoteMoyenne = (float)f.Avis.Select(a => a.Note).DefaultIfEmpty(0).Average() });
            }

            return View(vm);
        }

        public IActionResult TestRedirectionOk()
        {
            
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}