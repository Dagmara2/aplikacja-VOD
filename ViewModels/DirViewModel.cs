using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VOD.Models;

namespace VOD.ViewModels
{
	public class DirViewModel
	{
		public IEnumerable<Movie> Movies { get; set; }
		public IEnumerable<Dir> Dirs { get; set; }

	}
}