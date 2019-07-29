using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalMVCApplication.Models;
namespace MovieRentalMVCApplication.ViewModel
{
    public class NewMovieViewModel
    {
       public Movie Movie { get; set; }
        public IEnumerable<Genere> Generes { get; set; }
    }
}