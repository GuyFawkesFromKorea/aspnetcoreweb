using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcorewebapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapp.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            TempData["returnUrl"] = returnUrl;
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            ReturnObj rtnObj = new ReturnObj();

            if (model.Id == "h20913" && model.Pw == "wcw123")
            {
                return Json(rtnObj);
            }

            rtnObj.RtnCd = "-1";
            rtnObj.RtnMsg = "아이디/암호를 다시 확인하세요.";

            return View();
        }

        [HttpPost]        
        public IActionResult LoginFromBody([FromBody]LoginModel /*dynamic*/ model)
        {
            ReturnObj rtnObj = new ReturnObj();

            if (model.Id == "h20913" && model.  Pw == "wcw123")
            {
                return Json(rtnObj);
            }

            rtnObj.RtnCd = "-1";
            rtnObj.RtnMsg = "아이디/암호를 다시 확인하세요.";

            return Json(rtnObj);
        }
    }
}