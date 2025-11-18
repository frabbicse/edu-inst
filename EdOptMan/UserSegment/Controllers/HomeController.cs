using AcademicSegment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserSegment.Models;

namespace AcademicSegment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeModel homeModel = new HomeModel
            {
                CurrentUser = User.Identity?.Name ?? "Guest",
                TotalStudents = 1200,
                NewStudentsThisMonth = 75,
                TotalTeachers = 85,
                NewTeachersThisMonth = 5,
                TotalCourses = 200,
                ActiveCoursesPercentage = 82.5,
                TotalStaff = 40,
                DepartmentsCount = 8
            };
            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
