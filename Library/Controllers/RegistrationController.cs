using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <returns></returns>
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            RegistrationModel.AddUserToDB(user);
            return RedirectToAction("index", "Home");
        }

    }
}
