using Microsoft.AspNetCore.Mvc;
using UserSegment.Models;
using UserSegment.Services.Interface;

namespace UserSegment.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _stafService;
        private readonly ILogger<StaffController> _logger;

        public StaffController(IStaffService staffService, ILogger<StaffController> logger)
        {
            _stafService = staffService;
            _logger = logger;
        }
 
        public async Task<IActionResult> Index()
        {
            var staffs = await _stafService.GetStaffs();
            return View(staffs);
        }

        [HttpGet]
        public IActionResult StaffInfo()
        {
            return View();
        }


        // POST: Room/Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveStaffInfo(StaffEntryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var result = await _stafService.SaveStaff(model);
                    ViewBag.Success = result;
                    return View("Index", "Staff");

                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in saving room");
                return View(model);
            }


        }

        [HttpGet]
        public async Task<IActionResult> StaffDetail(int id)
        {
            try
            {
                var staffDetails = await _stafService.GetStaffById(id);
                return View(staffDetails);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in staff");
                return View("Index","Staff");

            }
        }

        [HttpGet]
        public async Task<IActionResult> EditStaff(int id)
        {
            var model = await _stafService.GetStaffById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStaffInfo(StaffEntryModel model)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                var res = await _stafService.UpdateStaff(model);
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

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var del = await _stafService.DeleteStaff(id);
                return RedirectToAction("Index","Staff");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in delete");
                return View("StaffDetail", "Staff");

            }
        }

    }
}
