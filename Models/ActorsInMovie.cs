using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VOD.Models
{
	public class ActorsInMovie
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Actor")]
		public string ActorName { get; set; }

		public int MovieId { get; set; }

	}
}