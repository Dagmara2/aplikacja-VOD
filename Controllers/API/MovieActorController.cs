using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VOD.Dtos;
using VOD.Models;
using VOD.Modelss;

namespace VOD.Controllers.API
{
	public class MovieActorController : ApiController
	{
		private ApplicationDbContext _context;

		public MovieActorController()
		{
			_context = new ApplicationDbContext();
		}
		[HttpPost]
		public IHttpActionResult CreateNewMovieActor(MovieActorDto movieActorDto)
		{
			var movie = _context.Movies.Single(
				m => m.Id == movieActorDto.MovieId);

			var actors = _context.Actors.Where(
				a => movieActorDto.ActorIds.Contains(a.Id)).ToList();

			foreach (var actor in actors)
			{
				var movieActor = new MovieActor
				{
					Movie = movie,
					Actor = actor
				};
				_context.MovieActors.Add(movieActor);
			}
			_context.SaveChanges();

			return Ok();
		}
	}
}
