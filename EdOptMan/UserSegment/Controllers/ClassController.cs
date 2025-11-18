using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly ILogger<ClassController> _logger;

        public ClassController(IClassService classService, ILogger<ClassController> logger)
        {
            _classService = classService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var classList = await _classService.GetClass();
                return View(classList);
            }
            catch (Exception ex)
            {
                _logger.LogError("Class List", ex);
                throw;
            }

        }

        public IActionResult ClassInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveClassInfo(ClassEntryModel classEntryModel)
        {
            try
            {
                var res = _classService.SaveClass(classEntryModel);

                ViewBag.Success = res;
                if (res.Result == true)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in SaveClassInfo");
                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult >EditClass(int id)
        {
            var model = await _classService.GetClassById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateClassInfo(ClassEntryModel model)
        {
            try
            {
               
                //if (ModelState.IsValid)
                //{
                var res = await _classService.UpdateClass(model);
                ViewBag.Success = res;
                return RedirectToAction("Index");
                //}

                //return View("EditClass", model);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in SaveClassInfo");
                return View("EditClass", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model =await _classService.GetClassById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var del = await _classService.DeleteClass(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in delete");
                return View("Delete","Class");
                 
            }
        }


    }
}
