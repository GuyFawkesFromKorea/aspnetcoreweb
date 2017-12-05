using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnetcorewebapp.Models;

namespace aspnetcorewebapp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        const string SessionKeyDate = "DtNow";
        public IActionResult SetDate() {
            HttpContext.Session.Set<DateTime>(SessionKeyDate, DateTime.Now);
            return RedirectToAction("GetDate");
        }

        public IActionResult GetDate() {
            var date = HttpContext.Session.Get<DateTime>(SessionKeyDate);
            var sessionTime = date.TimeOfDay.ToString();
            var currentTime = DateTime.Now.TimeOfDay.ToString();

            return Content($"Current time:{currentTime} - Session time:{sessionTime}");
        }
    }
}
