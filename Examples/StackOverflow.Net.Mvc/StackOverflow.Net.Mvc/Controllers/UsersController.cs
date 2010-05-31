using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverflow.Net.Mvc.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Users()
        {
            return View();
        }
    }
}
