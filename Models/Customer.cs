using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VOD.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public bool SubscribedToNewsletter { get; set; }
		public MembershipType MembershipType { get; set; }
		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }
		//[Display(Name="Date of Birth")]
		[AgeValidationMembership]
		public DateTime? Birthdate { get; set; }
	}

}