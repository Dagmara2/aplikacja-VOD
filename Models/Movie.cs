using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace VOD.Models
{
	public class Movie
	{
		
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DateAdded { get; set; }
		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }
		public Dir Dir { get; set; }
		[Required]
		[Display(Name = "Director")]
		public int DirId { get; set; }
		public Genre Genre { get; set; }
		[Required]
		[Display(Name = "Genre")]
		public byte GenreId { get; set; }
		[Display(Name = "Actor")]
		public int ActorId { get; set; }


	}
}