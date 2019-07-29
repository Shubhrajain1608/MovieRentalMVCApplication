using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalMVCApplication.Models
{


    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "movie name is mandatory")]
        [StringLength(50)]

        public string MovieName { get; set; }

        public DateTime Releasedate { get; set; }

        public DateTime DateAdded { get; set; }

        public int stock { get; set;}

        public Genere Genere { get; set; }
        public int GenereId { get; set; }
    }
}