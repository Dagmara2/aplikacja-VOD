using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VOD.Models;

namespace VOD.ViewModels
{
	public class NewDirViewModel
	{
		public int? Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		
		public string Title
		{
			get
			{
				//return Id != 0 ? "Edit Movie" : "New Movie";
				if (Id != 0)
					return "Edit Director";

				return "New Director";
			}
		}
		public NewDirViewModel()
		{
			Id = 0;
		}
		public NewDirViewModel(Dir dir)
		{
			Id = dir.Id;
			Name = dir.Name;

		}
	}
}