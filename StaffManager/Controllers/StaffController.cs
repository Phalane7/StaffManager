
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffManager.Services;

namespace StaffManager.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login", "Access");
            }

            var staff = _staffService.GetAllStaff();

            return View(staff);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login", "Access");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(StaffManager.Models.StaffMember staff)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login", "Access");
            }

            _staffService.AddStaff(staff);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login", "Access");
            }

            var staff = _staffService.GetStaffById(id);

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        [HttpPost]
        public IActionResult Edit(StaffManager.Models.StaffMember staff)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login", "Access");
            }

            _staffService.UpdateStaff(staff);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login", "Access");
            }

            var staff = _staffService.GetStaffById(id);

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login", "Access");
            }

            _staffService.DeleteStaff(id);

            return RedirectToAction("Index");
        }
    }
}

