using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VOD.Models;

namespace VOD.Modelss
{
	public class Rental
	{
		public int Id { get; set; }

		public string UserName { get; set; }

		public string MovieName { get; set; }

		public DateTime DateRented { get; set; }

	}
}