using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserSegment.Data;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            this._logger = logger;
            this._courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _courseService.GetCourse();
            return View(list);
        }

        public IActionResult CourseInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveCourseInfo(CourseEntryModel courseEntryModel)
        {
            try
            {
                var res =  _courseService.SaveCourse(courseEntryModel);
                ViewBag.Success = res;
                if (res.Result == true)
                {
                    return RedirectToAction("Index","Course");
                }
                return RedirectToAction("Index", "Course");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in SaveCourseInfo");
                return RedirectToAction("CourseInfo"); ;
            }
        }

        [HttpGet]
        public async Task<IActionResult> CourseDetail(int id)
        {
            try
            {
                var courseDetails = await _courseService.GetCourseById(id);
                return View(courseDetails);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in ViewCourse");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditCourse(int id)
        {
            try
            {
                var courseDetails = await _courseService.GetCourseById(id);
                return View(courseDetails);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in EditCourse");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCourseInfo(CourseEntryModel courseEntryModel)
        {
            try
            {
                var res = await _courseService.UpdateCourse(courseEntryModel);
                ViewBag.Success = res;
                return RedirectToAction("Index","Course");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in EditCourse");
                return RedirectToAction("EditCourse", courseEntryModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var res = await _courseService.DeleteCourse(id);
                if (res)
                {
                    return RedirectToAction("Index", "Course");
                }
                return RedirectToAction("Index", "Course");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in DeleteCourse");
                throw;
            }
        }


    }
}
