using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VOD.Models;
using VOD.Modelss;
using VOD.Dtos;

namespace VOD.Controllers.API
{
	public class ActorsController : ApiController
	{
		private ApplicationDbContext _context;

		public ActorsController()
		{
			_context = new ApplicationDbContext();
		}
		// GET /api/actors
		public IEnumerable<Actor> GetActors()
		{
			return _context.Actors.ToList();
		}
		// GET /api/actors/1
		public Actor GetActor(int id)
		{
			var actor = _context.Actors.SingleOrDefault(a => a.Id == id);
			if (actor == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			return actor;
		}
		// POST api/actors
		[HttpPost]
		public Actor CreateActor(Actor actor)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			_context.Actors.Add(actor);
			_context.SaveChanges();

			return actor;
		}
		// PUT /api/actors/1
		[HttpPut]
		public void UpdateActor(int id, Actor actor)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var actorInDb = _context.Actors.SingleOrDefault(a => a.Id == id);

			if (actorInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			actorInDb.Name = actor.Name;

			_context.SaveChanges();
		}
		// DELETE /api/actors/1
		[HttpDelete]
		public void DeleteActor(int id)
		{
			var actorInDb = _context.Actors.SingleOrDefault(a => a.Id == id);

			if (actorInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Actors.Remove(actorInDb);
			_context.SaveChanges();
		}
	}
}
