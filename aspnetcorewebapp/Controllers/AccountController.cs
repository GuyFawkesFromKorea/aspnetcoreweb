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
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ReturnObj Login(string id = "", string pw = "", string returnUrl = "")
        {
            ReturnObj rtnObj = new ReturnObj();

            if (id == "h20913" && pw == "1234")
            {
                return rtnObj;
            }

            rtnObj.RtnCd = "-1";
            rtnObj.RtnMsg = "아이디/암호를 다시 확인하세요.";

            return rtnObj;
        }
    }
}