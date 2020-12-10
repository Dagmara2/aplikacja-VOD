using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using VOD.Models;
using VOD.ViewModels;
using Microsoft.AspNet.Identity;
using VOD.Modelss;
using VOD.Dtos;

namespace VOD.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;
		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ViewResult Index()
		{

			//var movies = _context.Movies.Include(m => m.Genre).ToList();

			//return View(movies);
			if (User.IsInRole(RoleName.CanManageMovies))
				return View("List");
			else
				return View("ReadOnlyList");
		}
		public ActionResult Details(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).Include(m => m.Dir).SingleOrDefault(m => m.Id == id);
			//var actor = _context.Movies.Include(m => m.Actor).SingleOrDefault(m => m.Id == id);

			if (movie == null)
				return HttpNotFound();
		//	if (actor == null)
			//	return HttpNotFound();

			return View(movie);
		}
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult New()
		{
			var genres = _context.Genres.ToList();
			var dirs = _context.Dirs.ToList();
			var viewModel = new NewMovieViewModel
			{
				Genres = genres,
				Dirs = dirs
			};
			return View("MovieFullForm", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewMovieViewModel(movie)
				{
					Genres = _context.Genres.ToList(),
					Dirs = _context.Dirs.ToList()
				};
				return View("MovieFullForm", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}

			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.Description = movie.Description;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.DirId = movie.DirId;
				movieInDb.ActorId = movie.ActorId;

			}
			_context.SaveChanges();
			return RedirectToAction("EditFull", "Movies", new { movie.Id });
			//return RedirectToAction("Index", "Movies", new { movie.Id });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SaveFull(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new NewMovieViewModel(movie)
				{
					//Movie = movie,
					Genres = _context.Genres.ToList(),
					Dirs = _context.Dirs.ToList()

				};

				return View("MovieForm", viewModel);
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.Description = movie.Description;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.DirId = movie.DirId;
				movieInDb.ActorId = movie.ActorId;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies", new { movie.Id });
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
			if (movie == null)
				return HttpNotFound();

			var viewModel = new NewMovieViewModel(movie)
			{

				Genres = _context.Genres.ToList(),
				Dirs = _context.Dirs.ToList()
			};

			return View("MovieForm", viewModel);
		}
		public ActionResult EditFull(int id)
		{
			ViewBag.FormId = id;

			var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

			if (movie == null)
				return HttpNotFound();

			var viewModel = new NewMovieViewModel(movie)
			{
				Genres = _context.Genres.ToList(),
				Dirs = _context.Dirs.ToList()

			};

			return View("MovieFullForm", viewModel);
		}

		public ActionResult Rent(int id)
		{
			var currentUser = User.Identity.GetUserName();
			var movieName = _context.Movies.Where(m => m.Id == id).Select(m => m.Name).SingleOrDefault();

			var newRental = new Rental()
			{
				MovieName = movieName,
				UserName = currentUser,
				DateRented = DateTime.Now,
			};

			_context.Rentals.Add(newRental);

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");
		}
		public ActionResult MyMovies()
		{
			var currentUser = User.Identity.GetUserName();
			
			var allMovies = _context.Rentals.Where(u => u.UserName == currentUser).ToList();

			return View(allMovies);
		}

		// BEGIN Table in movieForm

		public ActionResult GetData(int id)
		{
			List<ActorsInMovie> actorsList = _context.ActorsInMovies.Where(x => x.MovieId == id).ToList<ActorsInMovie>();
			//List<ActorsInMovie> actorsList = db.ActorsInMovies.ToList<ActorsInMovie>();
			return Json(new { data = actorsList }, JsonRequestBehavior.AllowGet);
		}


		[HttpGet]
		public ActionResult AddOrEdit(int id = 0)
		{

			if (id == 0)
			{
				ViewBag.FormId = id;

				var aim = new ActorsInMovie();

				return View(aim);
			}
			else
			{
				return View(_context.ActorsInMovies.Where(x => x.Id == id).FirstOrDefault<ActorsInMovie>());
			}
		}

		[HttpGet]
		public ActionResult AddOrEdit1(int id)
		{

			ViewBag.FormId = id;

			var aim = new ActorsInMovie()
			{
				MovieId = id,
			};

			return View(aim);

		}



		[HttpPost]
		public ActionResult AddOrEdit(ActorsInMovie aim, int id)
		{

			if (aim.MovieId == id)
			{
				var newAim = new ActorsInMovie()
				{
					Id = 0,
					ActorName = aim.ActorName,
					MovieId = id,
				};

				_context.ActorsInMovies.Add(newAim);
				_context.SaveChanges();

				return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
			}
			else
			{
				_context.Entry(aim).State = EntityState.Modified;
				_context.SaveChanges();
				return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
			}


		}

		[HttpPost]
		public ActionResult Delete(int id)
		{

			ActorsInMovie aim = _context.ActorsInMovies.Where(x => x.Id == id).FirstOrDefault<ActorsInMovie>();
			_context.ActorsInMovies.Remove(aim);
			_context.SaveChanges();
			return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
		}
	}
}