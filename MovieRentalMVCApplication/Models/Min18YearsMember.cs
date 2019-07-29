using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalMVCApplication.Models
{
    public class Min18YearsMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId==0 ||customer.MembershipTypeId==1)
            {
                return ValidationResult.Success;
            }
            if (customer.DOB == null)
                return new ValidationResult("birthdate is required");
            var age = DateTime.Today.Year - customer.DOB.Year;
            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("should be greater then 18 years to avail membership");
            //creating instance of class but which class ->customer
          
        }
    }
}