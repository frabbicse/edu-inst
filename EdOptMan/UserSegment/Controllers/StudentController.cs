using Microsoft.AspNetCore.Mvc;

namespace UserSegment.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
