using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VOD.Models;


namespace VOD.ViewModels
{
	public class NewActorViewModel
	{
		public int? Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public string Title
		{
			get
			{
				if (Id != 0)
					return "Edit Actor";

				return "New Actor";
			}
		}
		public NewActorViewModel()
		{
			Id = 0;
		}
		public NewActorViewModel(Actor actor)
		{
			Id = actor.Id;
			Name = actor.Name;

		}
	}
}