using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace VOD.Models
{
	public class Actor
	{
		
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
	}
}