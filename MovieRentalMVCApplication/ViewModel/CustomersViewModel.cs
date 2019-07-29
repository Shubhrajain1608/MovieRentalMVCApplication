using MovieRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMVCApplication.ViewModel
{
    public class CustomersViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public int MyProperty { get; set; }
    }
}