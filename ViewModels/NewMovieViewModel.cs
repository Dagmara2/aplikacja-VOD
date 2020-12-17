using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VOD.Models;
using System.Collections.ObjectModel;

namespace VOD.ViewModels
{
	public class NewMovieViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public IEnumerable<Dir> Dirs { get; set; }
	
		public int? Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public string Description { get; set; }
		[Display(Name = "Release Date")]
		[Required]
		public DateTime? ReleaseDate { get; set; }
		[Display(Name = "Director")]
		[Required]
		public int? DirId { get; set; }
		[Display(Name = "Genre")]
		[Required]
		public byte? GenreId { get; set; }
		[Display(Name = "Actor")]
		[Required]
		public int? ActorId { get; set; }
		public string Title
		{
			get
			{
				//return Id != 0 ? "Edit Movie" : "New Movie";
				if (Id != 0)
					return "Edit Movie";

				return "New Movie";
			}
		}
		public NewMovieViewModel()
		{
			Id = 0;
		
		}
		public NewMovieViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			Description = movie.Description;
			ReleaseDate = movie.ReleaseDate;
			GenreId = movie.GenreId;
			DirId = movie.DirId;
			ActorId = movie.ActorId;
		}
	}
}