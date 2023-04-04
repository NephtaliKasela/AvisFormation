using AvisFormation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class Contact : Controller
    {
        public IActionResult Index()
        {
            var vm = new ContactViewModel();
            return View(vm);
        }

        public IActionResult SaveMessage(ContactViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("index", viewModel);
            }

            return View(viewModel);
        }
    }
}