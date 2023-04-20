using AvisFormation.Models;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace AvisFormation.Controllers
{
    public class Contact : Controller
    {
        IContactRepository _context;
        public Contact(IContactRepository context)
        { 
            _context = context;
        }
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

            _context.SaveMessage(viewModel.Name, viewModel.Email, viewModel.Message);

            return View(viewModel);
        }
    }
}