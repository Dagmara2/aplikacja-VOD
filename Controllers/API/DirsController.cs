using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VOD.Models;
using VOD.Modelss;


namespace VOD.Controllers.API
{
	public class DirsController : ApiController
	{
		private ApplicationDbContext _context;

		public DirsController()
		{
			_context = new ApplicationDbContext();
		}
		// GET /api/dirs
		public IEnumerable<Dir> GetDirs()
		{
			return _context.Dirs.ToList();
		}
		// GET /api/dirs/1
		public Dir GetDir(int id)
		{
			var dir = _context.Dirs.SingleOrDefault(d => d.Id == id);
			if (dir == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			return dir;
		}
		// POST api/dirs
		[HttpPost]
		public Dir CreateDir(Dir dir)
		{
			if(!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			_context.Dirs.Add(dir);
			_context.SaveChanges();

			return dir;
		}
		// PUT /api/dirs/1
		[HttpPut]
		public void UpdateDir(int id, Dir dir)
		{
			if (!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);

			var dirInDb = _context.Dirs.SingleOrDefault(d => d.Id == id);

			if(dirInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			dirInDb.Name = dir.Name;

			_context.SaveChanges();
		}
		// DELETE /api/dirs/1
		[HttpDelete]
		public void DeleteDir(int id)
		{
			var dirInDb = _context.Dirs.SingleOrDefault(d => d.Id == id);

			if (dirInDb == null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Dirs.Remove(dirInDb);
			_context.SaveChanges();
		}

	}
}
