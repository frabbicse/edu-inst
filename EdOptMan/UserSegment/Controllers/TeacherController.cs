using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ITeacherService teacherService, ILogger<TeacherController> logger)
        {
            _teacherService = teacherService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherService.GetTeachers();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult TeacherInfo()
        {
            return View();
        }

        // POST: Room/Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTeacherInfo(TeacherEntryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var result = await _teacherService.SaveTeacher(model);
                    ViewBag.Success = result;
                    return View("Index", "Teacher");

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
        public async Task<IActionResult> TeacherDetail(int id)
        {
            try
            {
                var teacherDetails = await _teacherService.GetTeacherById(id);
                return View(teacherDetails);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in studen");
                return View("Index", "Teacher");

            }
        }

        [HttpGet]
        public async Task<IActionResult> EditTeacher(int id)
        {
            var model = await _teacherService.GetTeacherById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTeacherInfo(TeacherEntryModel model)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                var res = await _teacherService.UpdateTeacher(model);
                ViewBag.Success = res;
                return RedirectToAction("Index");
                //}

                //return View("EditClass", model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in Save student info");
                return View("EditTeacher", model);
            }
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var del = await _teacherService.DeleteTeacher(id);
                return RedirectToAction("Index", "Teacher");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in delete");
                return View("TeacherDetail", "Teacher");

            }
        }

    }
}
