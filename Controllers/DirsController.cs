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
	public class DirsController : Controller
	{
		private ApplicationDbContext _context;
		public DirsController()
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
			//NewDirViewModel dirViewModel = new NewDirViewModel();
			
			
			var dir = _context.Dirs.SingleOrDefault(m => m.Id == id);
			var movies = _context.Movies.Where(m => m.DirId == id).ToList();
			ViewBag.Movies = movies;
			ViewBag.Dirs = dir;
			//dirViewModel.Movies = movies;

			if (dir == null)
				return HttpNotFound();

			return View();
		}
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult New()
		{
			var viewModel = new NewDirViewModel();
			return View("DirForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Dir dir)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewDirViewModel(dir);
				return View("DirForm", viewModel);
			}

			if (dir.Id == 0)
			{
				_context.Dirs.Add(dir);
			}

			else
			{
				var dirInDb = _context.Dirs.Single(m => m.Id == dir.Id);

				dirInDb.Name = dir.Name;
				

			}
			_context.SaveChanges();

			return RedirectToAction("Index", "Dirs");
		}
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Edit(int id)
		{
			var dir = _context.Dirs.SingleOrDefault(m => m.Id == id);
			if (dir == null)
				return HttpNotFound();

			
			var viewModel = new NewDirViewModel(dir);

			return View("DirForm", viewModel);
		}


	}
}