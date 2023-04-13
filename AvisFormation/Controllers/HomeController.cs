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
            var listFormation = _repository.GetFormations(2);
            return View(listFormation);
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