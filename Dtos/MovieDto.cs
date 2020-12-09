using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VOD.Models;

namespace VOD.Dtos
{
	public class MovieDto
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public string Description { get; set; }
		[Required]
		public int DirId { get; set; }
		public DirDto Dir { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime ReleaseDate { get; set; }
		[Required]
		public byte GenreId { get; set; }
		public GenreDto Genre { get; set; }
	}
}