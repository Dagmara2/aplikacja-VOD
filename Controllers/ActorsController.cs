using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using VOD.Models;
using VOD.ViewModels;

namespace VOD.Controllers
{
	public class ActorsController : Controller
	{
		private ApplicationDbContext _context;
		public ActorsController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ViewResult Index()
		{
			if (User.IsInRole(RoleName.CanManageMovies))
				return View("List");
			else
				return View("ReadOnlyList");
		}
		public ActionResult Details(int id)
		{
			var actor = _context.Actors.SingleOrDefault(m => m.Id == id);

			if (actor == null)
				return HttpNotFound();

			return View(actor);
		}
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult New()
		{
			var viewModel = new NewActorViewModel();
			return View("ActorForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Actor actor)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewActorViewModel(actor);
				return View("ActorForm", viewModel);
			}

			if (actor.Id == 0)
			{
				_context.Actors.Add(actor);
			}

			else
			{
				var actorInDb = _context.Actors.Single(m => m.Id == actor.Id);

				actorInDb.Name = actor.Name;


			}
			_context.SaveChanges();

			return RedirectToAction("Index", "Actors");
		}
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Edit(int id)
		{
			var actor = _context.Actors.SingleOrDefault(m => m.Id == id);
			if (actor == null)
				return HttpNotFound();


			var viewModel = new NewActorViewModel(actor);

			return View("ActorForm", viewModel);
		}


	}
}