using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UserSegment.Models;
using UserSegment.Services.Implementation;
using UserSegment.Services.Interface;

namespace UserSegment.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomService roomService, ILogger<RoomController> logger)
        {
            _roomService = roomService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _roomService.GetRooms();
            return View(rooms);
        }

        [HttpGet]
        public IActionResult RoomInfo()
        {
            return View();
        }
 

        // POST: Room/Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRoomInfo(RoomEntryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var result = await _roomService.SaveRoom(model);
                    ViewBag.Success = result;
                    return View("Index", "Room");

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
        public async Task<IActionResult> RoomDetail(int id)
        {
            try
            {
                var courseDetails = await _roomService.GetRoomById(id);
                return View(courseDetails);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in ViewCourse");
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditRoom(int id)
        {
            var model = await _roomService.GetRoomById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoomInfo(RoomEntryModel model)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                var res = await _roomService.UpdateRoom(model);
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
                var del = await _roomService.DeleteRoom(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in delete");
                return View("Delete", "Room");

            }
        }
    }
}
