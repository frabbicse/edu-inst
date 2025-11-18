using Microsoft.AspNetCore.Mvc;
using UserSegment.Models;
using UserSegment.Services.Implementation;

namespace UserSegment.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly RegistrationService _registrationService;

        public RegistrationController(RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (_registrationService.RegisterUser(model))
                {
                    return RedirectToAction("Index", "Login");
                }
                ModelState.AddModelError("", "Username already exists.");
            }
            return View(model);
        }
    }
}