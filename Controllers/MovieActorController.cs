using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VOD.Controllers
{
    public class MovieActorController : Controller
    {
        // GET: MovieActor
        public ActionResult New()
        {
            return View();
        }
    }
}