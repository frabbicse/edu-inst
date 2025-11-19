using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var students = await  _studentService.GetStudents();
            return View(students);
        }

        [HttpGet]
        public IActionResult StudentInfo()
        {
            return View();
        }

        // POST: Room/Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveStudentInfo(StudentEntryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var result = await _studentService.SaveStudent(model);
                    ViewBag.Success = result;
                    return View("Index", "Student");

                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in saving student");
                return View(model);
            }


        }

        [HttpGet]
        public async Task<IActionResult> StudentDetail(int id)
        {
            try
            {
                var studentDetails = await _studentService.GetStudentById(id);
                return View(studentDetails);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in studen");
                return View("Index", "Student");

            }
        }

        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            var model = await _studentService.GetStudentById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStudentInfo(StudentEntryModel model)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                var res = await _studentService.UpdateStudent(model);
                ViewBag.Success = res;
                return RedirectToAction("Index");
                //}

                //return View("EditClass", model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in Save student info");
                return View("EditStudent", model);
            }
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var del = await _studentService.DeleteStudent(id);
                return RedirectToAction("Index", "Student");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in delete");
                return View("StudentDetail", "Student");

            }
        }

    }
}
