using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
       /// <summary>
       /// Контроллер Логина на сайте
       /// </summary>
       /// <param name="usr"></param>
       /// <returns></returns>
 
        //Залогиниться
        [HttpPost]
        public ActionResult Login(LogUsr usr)
        {
            if (LoginModel.IsUserExists(usr))
            {
                Helpers.AuthHelper.LogInUser(HttpContext, usr.Email);
                return RedirectToAction("index", "Home");
            }
            else { return RedirectToAction("index", "Home"); }
        }

       //Разлогиниться
        public ActionResult LogOff()
        {
            Helpers.AuthHelper.LogOffUser(HttpContext);
            return RedirectToAction("index", "Home");
        }

    }
}
