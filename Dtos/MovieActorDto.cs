using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VOD.Dtos
{
	public class MovieActorDto
	{
		public int MovieId { get; set; }
		public List<int> ActorIds { get; set; }
	}
}