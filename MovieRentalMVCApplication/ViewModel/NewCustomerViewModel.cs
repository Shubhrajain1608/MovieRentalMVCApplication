using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalMVCApplication.Models;
namespace MovieRentalMVCApplication.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }//better the to list can bring all the data inside 
        public Customer Customer { get; set; }
    }
}