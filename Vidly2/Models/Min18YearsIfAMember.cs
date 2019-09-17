using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly2.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId==MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirdtDate == null)
            {
                return new ValidationResult("Birthday is required");
            }

            int age = DateTime.Today.Year - customer.BirdtDate.Value.Year;
            if(age>18) { return ValidationResult.Success;}
            else
            {
                return new ValidationResult("You need to be older then 18");
            }
        }
    }
}