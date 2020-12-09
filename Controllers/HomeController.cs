using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VOD.Models;
using VOD.ViewModels;

namespace VOD.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (User.IsInRole(RoleName.CanManageMovies))
				return RedirectToAction("ShowAccounts", "Account");
			else
				return RedirectToAction("MyMovies", "Movies");

		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}