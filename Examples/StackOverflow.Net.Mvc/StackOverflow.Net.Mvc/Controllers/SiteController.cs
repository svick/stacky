using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.Net.Mvc;

namespace StackOverflow.Net.Mvc.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/

        public ActionResult Header()
        {
            Url.RequestContext.RouteData = RouteData;
            SiteState state = new SiteState(Url);
            HeaderModel model = new HeaderModel(state);
            return View(model);
        }

    }
}
