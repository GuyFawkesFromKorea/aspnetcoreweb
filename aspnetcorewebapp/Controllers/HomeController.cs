using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnetcorewebapp.Models;
using JWLibraryNetCore;

namespace aspnetcorewebapp.Controllers
{
    public class HomeController : Controller
    {
        const string SessionKeyName = "_Name";
        const string SessionKeyYearsMember = "_YearsMember";
        const string SessionKeyDate = "_Date";

        public IActionResult Index()
        {
            var dateNow = DateTime.Now.ToString(DateHelper.DateFormatType.YYYY_D_MM_D_DD);
            ViewBag.DateNow = dateNow;

            // Requires using Microsoft.AspNetCore.Http;
            HttpContext.Session.Set<string>(SessionKeyName, "Rick");
            HttpContext.Session.Set<Int32>(SessionKeyYearsMember, 3);

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

        #region memory session test
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
        #endregion

        #region redis session test
        public IActionResult SessionNameYears()
        {
            var name = HttpContext.Session.Get<string>(SessionKeyName);
            var yearsMember = HttpContext.Session.Get<Int32>(SessionKeyYearsMember);

            return Content($"Name: \"{name}\",  Membership years: \"{yearsMember}\"");
        }
        #endregion
    }
}
