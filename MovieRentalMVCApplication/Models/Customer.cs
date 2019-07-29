using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalMVCApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="customer name is mandatory")]
        [StringLength(50)]
        
        [Display(Name = "CustomerName")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsMember]
        public bool IsSuscribed { get; set; }
        public MembershipType membershipType { get; set; }
        [Display(Name = "MembershipTypes")]
        public int MembershipTypeId { get; set; }
        public DateTime DOB { get; set; }



    }
}