using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOD.Models
{
	public class MovieActor
	{
		public int Id { get; set; }
		[Required]
		public Movie Movie { get; set; }
		[Required]
		public Actor Actor { get; set; }
	
	}
}