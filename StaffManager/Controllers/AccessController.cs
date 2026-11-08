using Microsoft.AspNetCore.Mvc;

namespace StaffManager.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "ed9u6v6")
            {
                HttpContext.Session.SetString("IsAdmin", "true");

                return RedirectToAction("Index", "Staff");
            }

            ViewBag.Error = "Invalid username or password.";

            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
