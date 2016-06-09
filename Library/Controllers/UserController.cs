using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult UserAccount()
        {
            return View();
        }

    }
}
