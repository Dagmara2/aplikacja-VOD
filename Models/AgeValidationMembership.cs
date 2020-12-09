using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOD.Models
{
	public class AgeValidationMembership : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer)validationContext.ObjectInstance;

			if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
				return ValidationResult.Success;
			if (customer.Birthdate == null)
				return new ValidationResult("Birthdate is required");
			var IsOver18 = DateTime.Today.AddYears(-18) < customer.Birthdate.Value;


			//	return (age >= 18)
			return (!IsOver18)
				? ValidationResult.Success
				: new ValidationResult("Customer has to be 18 or over");
		}
	}
}