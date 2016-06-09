using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        /// <summary>
        /// Страница логина
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginPage()
        {
            return View();
        }

    }
}
